using System.Diagnostics;
using CoraCorpCM.Data;
using CoraCorpCM.Models;
using CoraCorpCM.Services;
using Microsoft.AspNetCore.Mvc;
using CoraCorpCM.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailSender emailSender;
        private readonly IMuseumRepository museumRepository;

        public HomeController(
            UserManager<ApplicationUser> userManager, 
            IEmailSender emailSender, 
            IMuseumRepository museumRepository)
        {
            this.userManager = userManager;
            this.emailSender = emailSender;
            this.museumRepository = museumRepository;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = userManager.GetUserAsync(User).Result;
                var museum = museumRepository.GetMuseumByUser(user);
                ViewData["Title"] = museum.ShortName;
                ViewData["MuseumName"] = museum.Name;
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
