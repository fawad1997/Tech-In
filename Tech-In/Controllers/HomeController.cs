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


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            if(user == null)
            {
                return View();
            }
            else
            {
                var userPersonalRow = _context.UserPersonalDetail.Where(a => a.UserId == user.Id).SingleOrDefault();
                if (userPersonalRow == null)
                {
                    return RedirectToAction("CompleteProfile", "Home");
                }
            }
            return View("Welcome");
        }

        [Authorize]
        public IActionResult CompleteProfile()
        {
            CompleteProfileVM vm = new CompleteProfileVM();
            ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
            return View(vm);
        }
        

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CompleteProfile(CompleteProfileVM vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetCurrentUser(HttpContext);
                UserPersonalDetail userPersonal = new UserPersonalDetail();
                userPersonal.CityId = vm.CityId;
                userPersonal.FirstName = vm.FirstName;
                userPersonal.LastName = vm.LastName;
                userPersonal.IsDOBPublic = vm.DOBVisibility;
                userPersonal.DOB = vm.DOB;
                if (vm.Gender == 0)
                {
                    userPersonal.Gender = Models.Model.Gender.Male;
                }
                else
                {
                    userPersonal.Gender = Models.Model.Gender.Female;
                }
                userPersonal.UserId = user.Id;
                _context.UserPersonalDetail.Add(userPersonal);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "User");
            }
            ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
            return View("CompleteProfile");
        }

        public List<Country> GetCountryList()
        {
            List<Country> countries = _context.Country.ToList();
            return countries;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
