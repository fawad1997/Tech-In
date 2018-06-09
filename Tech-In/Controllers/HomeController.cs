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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Tech_In.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
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
                var file = vm.ProfileImage;
                UserPersonalDetail userPersonal = new UserPersonalDetail();
                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        if ((file.Length / 1000) > 5000)
                        {
                            ViewBag.ProfilePic = "Image can't exceed 5Mb size";
                            return View();
                        }
                        string path = Path.Combine(_hostingEnvironment.WebRootPath, "images/users");
                        string extension = Path.GetExtension(file.FileName).Substring(1);
                        if (!(extension.ToLower() == "png" || extension.ToLower() == "jpg" || extension.ToLower() == "jpeg"))
                        {
                            ViewBag.ProfilePic = "Only png, jpg & jpeg are allowed";
                            return View();
                        }
                        string fileNam = user.Id.Substring(24) + "p." + extension;
                        using (var vs = new FileStream(Path.Combine(path, fileNam), FileMode.CreateNew))
                        {
                            await file.CopyToAsync(vs);
                        }
                        using (var img = SixLabors.ImageSharp.Image.Load(Path.Combine(path, fileNam)))
                        {
                            userPersonal.ProfileImage = $"/images/users/{fileNam}";
                        }
                    }
                }
                userPersonal.CityId = vm.CityId;
                userPersonal.FirstName = vm.FirstName;
                userPersonal.LastName = vm.LastName;
                userPersonal.IsDOBPublic = vm.DOBVisibility;
                userPersonal.DOB = vm.DOB;
                if (vm.Gender == 0)
                {
                    userPersonal.Gender = Gender.Male;
                }
                else
                {
                    userPersonal.Gender = Gender.Female;
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
