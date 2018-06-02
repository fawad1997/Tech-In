using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tech_In.Data;
using Tech_In.Models;
using Tech_In.Models.Model;
using Tech_In.Models.ViewModels.ProfileViewModels;
using Tech_In.Services;

namespace Tech_In.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            var uaertoAdd = new ApplicationUser();
            ProfileViewModel PVM = new ProfileViewModel();

            var pd = _context.UserPersonalDetail.SingleOrDefault(m => m.UserId == user.Id);
            //Populating Data To VM


            //User Personal Details
            PVM.UserPersonalVM.FirstName = pd.FirstName;
            PVM.UserPersonalVM.LastName = pd.LastName;
            PVM.UserPersonalVM.Summary = pd.Summary;
            PVM.UserPersonalVM.PhoneNo = user.PhoneNumber;
            PVM.UserPersonalVM.Email = user.Email;
            PVM.UserPersonalVM.DOB = pd.DOB;

            if (pd.Gender == Models.Model.Gender.Male)
                PVM.UserPersonalVM.Gender = Models.ViewModels.ProfileViewModels.Gender.Male;
            else
                PVM.UserPersonalVM.Gender = Models.ViewModels.ProfileViewModels.Gender.Female;
            PVM.UserPersonalVM.City = _context.City.Where(c => c.CityID == pd.CityID).FirstOrDefault();
            int conID = PVM.UserPersonalVM.City.CountryID;
            PVM.UserPersonalVM.Country = _context.Country.Where(cit => cit.CountryID==conID).FirstOrDefault();
            var cities = _context.City.ToList();
            var countries = _context.Country.ToList();
            foreach (var city in cities)
            {
                PVM.UserPersonalVM.Cities.Add(new SelectListItem { Value = city.CityID.ToString(), Text = city.CityName });
            }
            foreach (var country in countries)
            {
                PVM.UserPersonalVM.Countries.Add(new SelectListItem { Value = country.CountryID.ToString(), Text = country.CountryName });
            }

            return View(PVM);
        }


        [HttpPost]
        public IActionResult UpdatePersonalDetails(ProfileViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.GetCurrentUser(HttpContext);
                var pd = _context.UserPersonalDetail.Where(p => p.UserId == user.Id.ToString()).FirstOrDefault();
                //var pd = new UserPersonalDetail
                //{
                //    FirstName = vm.UserPersonalVM.FirstName,
                //    LastName = vm.UserPersonalVM.LastName,
                //    DOB = vm.UserPersonalVM.DOB,
                //    CityID = vm.UserPersonalVM.City.CityID
                //};
                _context.UserPersonalDetail.Update(pd);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Resume()
        {
            //Get Object from parameter and generate Resume
            //university = new University();
            //university.Name = "CUST";
            //university.Chancler = "Amir";
            //university.PublishedDate = new DateTime(1990, 08, 08);
            //university.City = "Islamabad";
            //university.Country = "Pakistan";
            //university.Students = GetStudents();
            //university.Address = "Kahota Road";

            PDFGenerator userPDF = new PDFGenerator();
            byte[] abytes = userPDF.PrepareReport();
            return File(abytes, "application/pdf");
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetID()
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            if (user == null)
                return View("Null");
            return Content(user.Id);
        }
        public IActionResult AddUserExperience()
        {
            return null;
        }
        public IActionResult UpdateUserExperience()
        {
            return null;
        }
        public IActionResult DeleteUserExperience()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserEducation(ProfileViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetCurrentUser(HttpContext);
                UserEducation userEducation = new UserEducation
                {
                    Title = vm.UserEducationVM.Title,
                    SchoolName = vm.UserEducationVM.SchoolName,
                    Details = vm.UserEducationVM.Details,
                    CurrentStatusCheck = true,
                    StartDate = vm.UserEducationVM.StartDate,
                    EndDate = vm.UserEducationVM.EndDate,
                    CityID = 1,
                    UserId = user.Id
                };
                _context.UserEducation.Add(userEducation);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return Content("Error" );
        }

    }
}