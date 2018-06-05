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
using Tech_In.Models.Database;
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
            //Check User Profile is complete or not
            var user = await _userManager.GetCurrentUser(HttpContext);
            var userPersonalRow = _context.UserPersonalDetail.Where(a => a.UserId == user.Id).SingleOrDefault();
            if (userPersonalRow == null)
            {
                return RedirectToAction("CompleteProfile", "Home");
            }


            ProfileViewModal PVM = new ProfileViewModal();

            PVM.UserPersonalVM = _context.UserPersonalDetail.Where(m => m.UserId == user.Id).Select(x => new UserPersonalViewModel { FirstName = x.FirstName,LastName=x.LastName,Summary=x.Summary,DOB=x.DOB, UserPersonalDetailID = x.UserPersonalDetailId, Gender = x.Gender,CityName = x.City.CityName, CountryName = x.City.Country.CountryName }).SingleOrDefault();
            
            PVM.UserPersonalVM.PhoneNo = user.PhoneNumber;
            PVM.UserPersonalVM.Email = user.Email;



            List<ExperienceVM> userExperienceList = _context.UserExperience.Where(x => x.UserId == user.Id).Select(c => new ExperienceVM { Title = c.Title, UserExperienceId = c.UserExperienceId, CityId = c.CityID, CityName = c.City.CityName, CountryName=c.City.Country.CountryName,CompanyName = c.CompanyName, CurrentWorkCheck = c.CurrentWorkCheck, Description = c.Description, StartDate = c.StartDate, EndDate = c.EndDate }).ToList();
            ViewBag.UserExperienceList = userExperienceList;

            List<EducationVM> userEducationList = _context.UserEducation.Where(x => x.UserId == user.Id).Select(c => new EducationVM { Title = c.Title, Details = c.Details, SchoolName = c.SchoolName, StartDate = c.StartDate, EndDate = c.EndDate, CurrentStatusCheck = c.CurrentStatusCheck, CityId = c.CityId, CityName = c.City.CityName, CountryName = c.City.Country.CountryName, UserEducationID=c.UserEducationId }).ToList();
            ViewBag.UserEducationList = userEducationList;

            List<CertificationVM> userCertificationList = _context.UserCertification.Where(x => x.UserId == user.Id).Select(c => new CertificationVM { Name = c.Name, URL = c.URL, UserCertificationId = c.UserCertificationId, LiscenceNo = c.LiscenceNo, CertificationDate = c.CertificationDate, ExpirationDate = c.ExpirationDate }).ToList();
            ViewBag.UserCertificationList = userCertificationList;
          //  ViewBag.CountryList = new SelectList(GetCountryList(), "CountryID", "CountryName");

            return View(PVM);
        }

        //Personal Details
        public async Task<IActionResult> UpdatePersonalDetail(int Id)
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
            UserPersonalViewModel vm = new UserPersonalViewModel();
            if (Id > 0)
            {
                UserPersonalDetail personalDetail = _context.UserPersonalDetail.SingleOrDefault(x => x.UserPersonalDetailId == Id);
                vm.UserPersonalDetailID = personalDetail.UserPersonalDetailId;
                vm.DOB = personalDetail.DOB;
                vm.FirstName = personalDetail.FirstName;
                vm.LastName = personalDetail.LastName;
                vm.PhoneNo = user.PhoneNumber;
                vm.Email = user.Email;
                vm.CityId = personalDetail.CityId;
                if (personalDetail.Gender == Gender.Male)
                {
                    vm.Gender = Gender.Male;
                }
                else
                {
                    vm.Gender = Gender.Female;
                }
            }
            else
            {
                return NotFound();
            }
            return PartialView(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersonalDetails(UserPersonalViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetCurrentUser(HttpContext);
                var pd = _context.UserPersonalDetail.Where(p => p.UserId == user.Id).FirstOrDefault();
                pd.FirstName = vm.FirstName;
                pd.LastName = vm.LastName;
                pd.DOB = vm.DOB;
                pd.CityId = vm.CityId;
                if (vm.Gender == 0)
                {
                    pd.Gender = Models.Model.Gender.Male;
                }
                else
                {
                    pd.Gender = Models.Model.Gender.Female;
                }
                user.PhoneNumber = vm.PhoneNo;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        

        //User Experience

        public IActionResult AddEditUserExperience(int Id)
        {
            ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
            ExperienceVM vm = new ExperienceVM();
            if (Id > 0)
            {
                UserExperience exp = _context.UserExperience.SingleOrDefault(x => x.UserExperienceId == Id);
                vm.Title = exp.Title;
                vm.CompanyName = exp.CompanyName;
                vm.CityId = exp.CityID;
                vm.CurrentWorkCheck = exp.CurrentWorkCheck;
                vm.Description = exp.Description;
                vm.StartDate = exp.StartDate;
                vm.EndDate = exp.EndDate;
                vm.UserExperienceId = Id;
            }
            return PartialView(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExperience(ExperienceVM vm)
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            if (vm.UserExperienceId > 0)
            {
                UserExperience exp= _context.UserExperience.SingleOrDefault(x => x.UserExperienceId == vm.UserExperienceId);
                exp.Title = vm.Title;
                exp.CompanyName = vm.CompanyName;
                exp.CityID = vm.CityId;
                exp.CurrentWorkCheck = vm.CurrentWorkCheck;
                exp.Description = vm.Description;
                exp.StartDate = vm.StartDate;
                exp.EndDate = vm.EndDate;
            }
            else
            {
                UserExperience exp = new UserExperience();
                exp.Title = vm.Title;
                exp.CompanyName = vm.CompanyName;
                exp.CityID = vm.CityId;
                exp.CurrentWorkCheck = vm.CurrentWorkCheck;
                exp.Description = vm.Description;
                exp.StartDate = vm.StartDate;
                exp.EndDate = vm.EndDate;
                exp.UserId = user.Id;
                _context.UserExperience.Add(exp);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
            //return View("Index");
        }

        public JsonResult DeleteUserExperience(int Id)
        {
            bool result = false;
            UserExperience exp = _context.UserExperience.SingleOrDefault(x => x.UserExperienceId == Id);
            if (exp != null)
            {
                _context.Remove(exp);
                _context.SaveChanges();
                result = true;
            }
            
            return Json(result);
        }

        //User Education
        public IActionResult AddEditUserEducation(int Id)
        {
            ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
            EducationVM vm = new EducationVM();
            if (Id > 0)
            {
                UserEducation edu = _context.UserEducation.SingleOrDefault(x => x.UserEducationId == Id);
                vm.Title = edu.Title;
                vm.SchoolName = edu.SchoolName;
                vm.Details = edu.Details;
                vm.StartDate = edu.StartDate;
                vm.EndDate = edu.EndDate;
                vm.CurrentStatusCheck = edu.CurrentStatusCheck;
                vm.CityId = edu.CityId;
                vm.UserEducationID = edu.UserEducationId;
            }
            return PartialView(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEducation(EducationVM vm)
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            if (vm.UserEducationID > 0)
            {
                UserEducation edu = _context.UserEducation.SingleOrDefault(x => x.UserEducationId == vm.UserEducationID);
                edu.Title = vm.Title;
                edu.SchoolName = vm.SchoolName;
                edu.CityId = vm.CityId;
                edu.CurrentStatusCheck = vm.CurrentStatusCheck;
                edu.Details = vm.Details;
                edu.StartDate = vm.StartDate;
                edu.EndDate = vm.EndDate;
            }
            else
            {
                UserEducation edu = new UserEducation();
                edu.Title = vm.Title;
                edu.SchoolName = vm.SchoolName;
                edu.CityId = vm.CityId;
                edu.CurrentStatusCheck = vm.CurrentStatusCheck;
                edu.Details = vm.Details;
                edu.StartDate = vm.StartDate;
                edu.EndDate = vm.EndDate;
                edu.UserId = user.Id;
                _context.UserEducation.Add(edu);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
            //return View("Index");
        }

        public JsonResult DeleteUserEducation(int Id)
        {
            bool result = false;
            UserEducation edu = _context.UserEducation.SingleOrDefault(x => x.UserEducationId == Id);
            if (edu != null)
            {
                _context.Remove(edu);
                _context.SaveChanges();
                result = true;
            }

            return Json(result);
        }

        //Certification
        public IActionResult AddEditUserCertification(int Id)
        {
            CertificationVM vm = new CertificationVM();
            if (Id > 0)
            {
                UserCertification cert = _context.UserCertification.SingleOrDefault(x => x.UserCertificationId == Id);
                vm.Name = cert.Name;
                vm.CertificationDate = cert.CertificationDate;
                vm.ExpirationDate = cert.ExpirationDate;
                vm.LiscenceNo = cert.LiscenceNo;
                vm.URL = cert.URL;
                vm.UserCertificationId = cert.UserCertificationId;
            }
            return PartialView(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCertification(CertificationVM vm)
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            if (vm.UserCertificationId > 0)
            {
                UserCertification cert = _context.UserCertification.SingleOrDefault(x => x.UserCertificationId == vm.UserCertificationId);
                cert.Name = vm.Name;
                cert.CertificationDate = vm.CertificationDate;
                cert.ExpirationDate = vm.ExpirationDate;
                cert.LiscenceNo = vm.LiscenceNo;
                cert.URL = vm.URL;
            }
            else
            {
                UserCertification cert = new UserCertification();
                cert.Name = vm.Name;
                cert.CertificationDate = vm.CertificationDate;
                cert.ExpirationDate = vm.ExpirationDate;
                cert.LiscenceNo = vm.LiscenceNo;
                cert.URL = vm.URL;
                cert.UserId = user.Id;
                _context.UserCertification.Add(cert);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
            //return View("Index");
        }

        public JsonResult DeleteUserCertification(int Id)
        {
            bool result = false;
            UserCertification cert = _context.UserCertification.SingleOrDefault(x => x.UserCertificationId == Id);
            if (cert != null)
            {
                _context.Remove(cert);
                _context.SaveChanges();
                result = true;
            }

            return Json(result);
        }

        public async Task<IActionResult> Resume()
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            ProfileViewModal pVM = new ProfileViewModal();
            //Personal Details
            pVM.UserPersonalVM = _context.UserPersonalDetail.Where(m => m.UserId == user.Id).Select(x => new UserPersonalViewModel { FirstName = x.FirstName, LastName = x.LastName, Summary = x.Summary, DOB = x.DOB, UserPersonalDetailID = x.UserPersonalDetailId, Gender = x.Gender, CityName = x.City.CityName, CountryName = x.City.Country.CountryName }).SingleOrDefault();
            pVM.UserPersonalVM.PhoneNo = user.PhoneNumber;
            pVM.UserPersonalVM.Email = user.Email;

            //Education
            pVM.EduVMList = _context.UserEducation.Where(x => x.UserId == user.Id).Select(c => new EducationVM { Title = c.Title, Details = c.Details, SchoolName = c.SchoolName, StartDate = c.StartDate, EndDate = c.EndDate, CurrentStatusCheck = c.CurrentStatusCheck, CityId = c.CityId, CityName = c.City.CityName, CountryName = c.City.Country.CountryName, UserEducationID = c.UserEducationId }).ToList();
            pVM.ExpVMList = _context.UserExperience.Where(x => x.UserId == user.Id).Select(c => new ExperienceVM { Title = c.Title, UserExperienceId = c.UserExperienceId, CityId = c.CityID, CityName = c.City.CityName, CountryName = c.City.Country.CountryName, CompanyName = c.CompanyName, CurrentWorkCheck = c.CurrentWorkCheck, Description = c.Description, StartDate = c.StartDate, EndDate = c.EndDate }).ToList();


            //Get Object from parameter and generate Resume
            //university = new University();
            //university.Name = "CUST";
            //university.Chancler = "Amir";
            //university.PublishedDate = new DateTime(1990, 08, 08);
            //university.City = "Islamabad";
            //university.Country = "Pakistan";
            //university.Students = GetStudents();
            //university.Address = "Kahota Road";

            PDFGenerator userPDF = new PDFGenerator(pVM);
            byte[] abytes = userPDF.PrepareReport();
            return File(abytes, "application/pdf");
        }

        public List<Country> GetCountryList()
        {
            List<Country> countries = _context.Country.ToList();
            return countries;
        }
        
        public IActionResult GetCitiesList(int CountryId)
        {
            List<City> cities = _context.City.Where(x => x.CountryId == CountryId).ToList();
            ViewBag.CitiesList = new SelectList(cities, "CityId", "CityName");
            return PartialView("CitiesPartial");
        }
        
    }
}