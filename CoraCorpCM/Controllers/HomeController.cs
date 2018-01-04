using System;
using System.Diagnostics;
using CoraCorpCM.Services;
using Microsoft.AspNetCore.Mvc;
using CoraCorpCM.ViewModels;

namespace CoraCorpCM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender emailSender;

        public HomeController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
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
                // TODO rig up real emailer in StartUp and indlude name here
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
