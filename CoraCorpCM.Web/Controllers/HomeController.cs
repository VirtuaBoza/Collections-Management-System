﻿using System.Diagnostics;
using CoraCorpCM.Web.Services;
using Microsoft.AspNetCore.Mvc;
using CoraCorpCM.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using CoraCorpCM.App.Membership;

namespace CoraCorpCM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(
            IEmailSender emailSender, 
            UserManager<ApplicationUser> userManager)
        {
            this.emailSender = emailSender;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = userManager.GetUserAsync(User).Result;
                ViewData["Title"] = user.Museum.ShortName;
                ViewData["MuseumName"] = user.Museum.Name;
            }
            else
            {
                ViewData["Title"] = "Home";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                emailSender.SendEmailAsync(model.Email, model.Subject, model.Message);
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
