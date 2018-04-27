using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoraCorpCM.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using CoraCorpCM.Common.Membership;
using CoraCorpCM.Application.Museums.Queries;
using CoraCorpCM.Application.Interfaces.Infrastructure;
using System.Security.Claims;

namespace CoraCorpCM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGetMuseumForUserIdQuery museumForUserIdQuery;

        public HomeController(
            IEmailSender emailSender, 
            UserManager<ApplicationUser> userManager,
            IGetMuseumForUserIdQuery museumForUserIdQuery)
        {
            this.emailSender = emailSender;
            this.userManager = userManager;
            this.museumForUserIdQuery = museumForUserIdQuery;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var museumModel = museumForUserIdQuery.Execute(User.FindFirstValue(ClaimTypes.NameIdentifier));
                ViewData["Title"] = museumModel.ShortName;
                ViewData["MuseumName"] = museumModel.Name;
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
