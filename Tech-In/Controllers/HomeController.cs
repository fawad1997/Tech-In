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
            var countries = _context.Countries.ToList();
            var cities = _context.Cities.ToList();
            foreach(var city in cities)
            {
                vm.Cities.Add(new SelectListItem { Value = city.CityID.ToString(), Text = city.CityName });
            }
            foreach(var country in countries)
            {
                vm.Countries.Add(new SelectListItem { Value = country.CountryID.ToString(), Text = country.CountryName });
            }
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddPersonalDetails(CompleteProfileVM profileVM)
        {
            UserPersonalDetail PersonalDetails = new UserPersonalDetail
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
                CityID=5

            };
            //PersonalDetails.CityID = 2;
            _context.UserPersonalDetails.Add(PersonalDetails);
            _context.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CompleteProfileAsync(CompleteProfileVM vM)
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            UserPersonalDetail userPersonal = new UserPersonalDetail();
            userPersonal.City = vM.City;
            userPersonal.CityID = vM.City.CityID;
            userPersonal.CVImage = vM.CVImage;
            userPersonal.DOB = vM.DOB;
            userPersonal.IsDOBPublic = vM.DOBVisibility;
            //userPersonal.Gender = vM.Gender;
            userPersonal.IsEmailPublic = true;
            userPersonal.IsPhonePublic = false;
            userPersonal.LastName = vM.LastName;
            userPersonal.FirstName = vM.FirstName;
            userPersonal.UserID = user.Id;
            _context.UserPersonalDetails.Add(userPersonal);
            await _context.SaveChangesAsync();
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
