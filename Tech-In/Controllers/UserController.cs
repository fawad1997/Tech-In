using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tech_In.Models;
using Tech_In.Services;

namespace Tech_In.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

    }
}