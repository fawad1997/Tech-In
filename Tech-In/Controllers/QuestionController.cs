using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tech_In.Data;
using Tech_In.Models;
using Tech_In.Models.Database;
using Tech_In.Models.ViewModels.QuestionViewModels;
using Tech_In.Services;

namespace Tech_In.Controllers
{

    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public QuestionController( ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
        [Authorize]
        public IActionResult New()
        {
            return View();
        }

        public IActionResult Xyz()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> PostQuestion(NewQuestionVM  vm)
        {
            var user = await _userManager.GetCurrentUser(HttpContext);
            if(ModelState.IsValid)
            {
                UserQuestion userQuestion = new UserQuestion();
                userQuestion.Title = vm.Title;
                userQuestion.Description = vm.Description;
                userQuestion.PostTime = DateTime.Now;
                userQuestion.UserId = user.Id;
                _context.UserQuestion.Add(userQuestion);
                _context.SaveChanges();

            }

            return View("Index");
        }

    }
}