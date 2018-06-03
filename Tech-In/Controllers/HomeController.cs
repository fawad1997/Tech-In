using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tech_In.Data;
using Tech_In.Models;
using Tech_In.Models.Model;
using Tech_In.Models.Database;
using Tech_In.Models.ViewModels.ProfileViewModels;
using Tech_In.Services;

namespace Tech_In.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult CompleteProfile()
        {
            CompleteProfileVM vm = new CompleteProfileVM();
            var countries = _context.Country.ToList();
            var cities = _context.City.ToList();
            foreach(var city in cities)
            {
                vm.Cities.Add(new SelectListItem { Value = city.CityId.ToString(), Text = city.CityName });
            }
            foreach(var country in countries)
            {
                vm.Countries.Add(new SelectListItem { Value = country.CountryId.ToString(), Text = country.CountryName });
            }
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddPersonalDetails(CompleteProfileVM profileVM)
        {
            var user = new ApplicationUser();

            UserPersonalDetail personalDetails = new UserPersonalDetail
            {
                ////PersonalDetails.UserPersonalDetailID = 1;
                FirstName = profileVM.FirstName,
                LastName = profileVM.LastName,
                //DOB = profileVM.DOB,
                //IsDOBPublic = profileVM.DOBVisibility,
                ////PersonalDetails.Gender = profileVM.Gender;
                //CVImage = profileVM.CVImage,
                //City = profileVM.City,
                //CityID = profileVM.City.CityID
                DOB = new DateTime(),
                IsDOBPublic=true,
                Gender=Models.Model.Gender.Male,
                CityID=1
            };
            //user.UserPersonalDetails.Add(personalDetails);
            //var result = _userManager.CreateAsync(user);
            
            return RedirectToAction("Index", "User");
            
            //return Content("Error");
            //_context.UserPersonalDetail.Add(PersonalDetails);
           // _context.SaveChanges();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CompleteProfileAsync(CompleteProfileVM vM)
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            UserPersonalDetail userPersonal = new UserPersonalDetail();
            userPersonal.City = vM.City;
            userPersonal.CityID = vM.City.CityId;
            userPersonal.CVImage = vM.CVImage;
            userPersonal.DOB = vM.DOB;
            userPersonal.IsDOBPublic = vM.DOBVisibility;
            //userPersonal.Gender = vM.Gender;
            userPersonal.IsEmailPublic = true;
            userPersonal.IsPhonePublic = false;
            userPersonal.LastName = vM.LastName;
            userPersonal.FirstName = vM.FirstName;
            userPersonal.UserId = user.Id;
            _context.UserPersonalDetail.Add(userPersonal);
            await _context.SaveChangesAsync();
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
