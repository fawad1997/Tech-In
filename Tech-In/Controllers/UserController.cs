using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            ProfileViewModel PVM = new ProfileViewModel();

            var pd = _context.UserPersonalDetails.SingleOrDefault(m => m.UserID == user.Id);
            if (pd == null)
            {
                var uPersonal = new UserPersonalDetail() {
                    FirstName = user.Email,
                    LastName = null,
                    Summary = null,
                    UserID = user.Id,
                    CityID = 1
                };
                _context.UserPersonalDetails.Add(uPersonal);
                _context.SaveChanges();
            }
            PVM.UserPersonalVM.FirstName = pd.FirstName;
            //PVM.UserPersonalVM.LastName = pd.LastName;
            return View(PVM);
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

    }
}