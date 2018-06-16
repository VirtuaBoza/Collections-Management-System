using CoraCorpCM.Application.Interfaces.Infrastructure;
using CoraCorpCM.Application.Museums.Queries;
using CoraCorpCM.Common.Membership;
using CoraCorpCM.Common.Tests;
using CoraCorpCM.Web.Controllers;
using CoraCorpCM.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController controller;

        private Mock<IEmailSender> mockEmailSender;
        private Mock<UserManager<ApplicationUser>> mockUserManager;
        private Mock<IGetMuseumForUserIdQuery> mockMuseumForUserIdQuery;

        private Mock<ClaimsIdentity> mockClaimsIdentity;
        private MuseumModel museumModel;

        [TestInitialize]
        public void SetUp()
        {
            mockEmailSender = new Mock<IEmailSender>();

            mockUserManager = CommonMockHelper.GetMockUserManager();

            mockMuseumForUserIdQuery = new Mock<IGetMuseumForUserIdQuery>();
            museumModel = new MuseumModel { ShortName = "ShortName", Name = "Name" };
            mockMuseumForUserIdQuery.Setup(q => q.Execute(It.IsAny<string>())).Returns(museumModel);

            controller = new HomeController(
                mockEmailSender.Object,
                mockUserManager.Object,
                mockMuseumForUserIdQuery.Object);

            mockClaimsIdentity = new Mock<ClaimsIdentity>();
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(c => c.Identity).Returns(mockClaimsIdentity.Object);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = mockClaimsPrincipal.Object }
            };
        }

        [TestMethod]
        public void Index_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_GivenUserIsAuthenticated_SetsTitleToMuseumShortName()
        {
            // Arrange
            mockClaimsIdentity.Setup(i => i.IsAuthenticated).Returns(true);

            // Act
            var result = controller.Index();

            // Assert
            Assert.AreEqual(museumModel.ShortName, controller.ViewData["Title"]);
        }

        [TestMethod]
        public void Index_GivenUserIsAuthenticated_SetsMuseumName()
        {
            // Arrange
            mockClaimsIdentity.Setup(i => i.IsAuthenticated).Returns(true);

            // Act
            var result = controller.Index();

            // Assert
            Assert.AreEqual(museumModel.Name, controller.ViewData["MuseumName"]);
        }

        [TestMethod]
        public void Index_GivenUserIsNotAuthenticated_SetsTitleToHome()
        {
            // Arrange
            mockClaimsIdentity.Setup(i => i.IsAuthenticated).Returns(false);

            // Act
            var result = controller.Index();

            // Assert
            Assert.AreEqual("Home", controller.ViewData["Title"]);
        }

        [TestMethod]
        public void Contact_OnGet_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = controller.Contact();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Contact_OnPost_ReturnsViewResult()
        {
            // Arrange
            var viewModel = new ContactViewModel();

            // Act
            var result = await controller.Contact(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Contact_OnPost_GivenValidModel_ReturnsSendsEmail()
        {
            // Arrange
            var viewModel = new ContactViewModel();

            // Act
            var result = await controller.Contact(viewModel);

            // Assert
            mockEmailSender.Verify(e => e.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        [TestMethod]
        public async Task Contact_OnPost_GivenValidModel_ClearsModelState()
        {
            // Arrange
            var viewModel = new ContactViewModel();

            // Act
            var result = await controller.Contact(viewModel);

            // Assert
            Assert.AreEqual(0, controller.ModelState.Count);
        }

        [TestMethod]
        public void Error_ReturnsViewResultWithErrorViewModel()
        {
            // Arrange
            // Act
            var result = controller.Error() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(ErrorViewModel));
        }
    }
}
