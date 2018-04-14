﻿using CoraCorpCM.App.Membership;
using CoraCorpCM.App.Tests;
using CoraCorpCM.Web.Controllers;
using CoraCorpCM.App.Interfaces.Infrastructure;
using CoraCorpCM.Web.ViewModels.ManageViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CoraCorpCM.Web.Services.Account;
using System;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class ManageControllerTests
    {
        ManageController controller;

        Mock<UserManager<ApplicationUser>> mockUserManager;
        Mock<SignInManager<ApplicationUser>> mockSignInManager;
        Mock<IEmailSender> mockEmailSender;
        Mock<ILogger<ManageController>> mockLogger;
        Mock<UrlEncoder> mockUrlEncoder;
        Mock<ICallbackUrlCreator> mockCallbackUrlCreator;

        ApplicationUser user;

        [TestInitialize]
        public void SetUp()
        {
            user = new ApplicationUser { Id = "1" };
            mockUserManager = AppMockHelper.GetMockUserManager();
            mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);

            mockSignInManager = WebMockHelper.GetMockSignInManager();

            mockEmailSender = new Mock<IEmailSender>();

            mockLogger = new Mock<ILogger<ManageController>>();

            mockUrlEncoder = new Mock<UrlEncoder>();

            mockCallbackUrlCreator = new Mock<ICallbackUrlCreator>();
            mockCallbackUrlCreator
                .Setup(c => c.CreateEmailConfirmationLink(It.IsAny<IUrlHelper>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns("callbackUrl");

            controller = new ManageController(
                mockUserManager.Object, 
                mockSignInManager.Object, 
                mockEmailSender.Object, 
                mockLogger.Object, 
                mockUrlEncoder.Object,
                mockCallbackUrlCreator.Object);

            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(r => r.Scheme).Returns("scheme");
            var mockContext = new Mock<HttpContext>();
            mockContext.Setup(c => c.Request).Returns(mockRequest.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
        }

        [TestMethod]
        public async Task GetIndex_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task GetIndex_ReturnsViewResultWithIndexViewModel()
        {
            // Arrange

            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(IndexViewModel));
        }

        [TestMethod]
        public async Task GetIndex_WhenUnableToLoadUser_ThrowsApplicationException()
        {
            // Arrange
            user = null;
            mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);

            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ApplicationException>(() => controller.Index());
        }

        [TestMethod]
        public async Task PostIndex_WithValidModel_ReturnsRedirectsToActionResult()
        {
            // Arrange
            var viewModel = new IndexViewModel();

            // Act
            var result = await controller.Index(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public async Task PostIndex_WithValidModel_SetsStatusMessage()
        {
            // Arrange
            var viewModel = new IndexViewModel();

            // Act
            var result = await controller.Index(viewModel);

            // Assert
            Assert.IsNotNull(controller.StatusMessage);
        }

        [TestMethod]
        public async Task PostIndex_WithInvalidModel_ReturnsViewResult()
        {
            // Arrange
            var viewModel = new IndexViewModel();
            controller.ModelState.AddModelError("error", "error");

            // Act
            var result = await controller.Index(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task PostIndex_WithInvalidModel_ReturnsViewResultWithModel()
        {
            // Arrange
            var viewModel = new IndexViewModel();
            controller.ModelState.AddModelError("error", "error");

            // Act
            var result = await controller.Index(viewModel) as ViewResult;

            // Assert
            Assert.AreSame(viewModel, result.Model);
        }

        [TestMethod]
        public async Task PostIndex_WhenUnableToLoadUser_ThrowsApplicationException()
        {
            // Arrange
            user = null;
            mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
            var viewModel = new IndexViewModel();

            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ApplicationException>(() => controller.Index(viewModel));
        }

        [TestMethod]
        public async Task PostIndex_WhenUnableToSetUserEmail_ThrowsApplicationException()
        {
            // Arrange
            var viewModel = new IndexViewModel();
            viewModel.Email = "someEmail";
            mockUserManager.Setup(um => um.SetEmailAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed());

            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ApplicationException>(() => controller.Index(viewModel));
        }

        [TestMethod]
        public async Task PostIndex_WhenUnableToSetUserPhoneNumber_ThrowsApplicationException()
        {
            // Arrange
            var viewModel = new IndexViewModel();
            viewModel.PhoneNumber = "somePhoneNumber";
            mockUserManager.Setup(um => um.SetPhoneNumberAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed());

            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ApplicationException>(() => controller.Index(viewModel));
        }

        [TestMethod]
        public async Task PostSendVerificationEmail_WithValidModel_ReturnsRedirectToActionResult()
        {
            // Arrange
            var viewModel = new IndexViewModel();

            // Act
            var result = await controller.SendVerificationEmail(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public async Task PostSendVerificationEmail_WithValidModel_SetsStatusMessage()
        {
            // Arrange
            var viewModel = new IndexViewModel();

            // Act
            var result = await controller.SendVerificationEmail(viewModel);

            // Assert
            Assert.IsNotNull(controller.StatusMessage);
        }

        [TestMethod]
        public async Task PostSendVerificationEmail_WithValidModel_SendsEmailConfirmation()
        {
            // Arrange
            var viewModel = new IndexViewModel();

            // Act
            var result = await controller.SendVerificationEmail(viewModel);

            // Assert
            mockEmailSender.Verify(e => e.SendEmailConfirmationAsync(It.IsAny<string>(), It.IsAny<string>()));
        }

        [TestMethod]
        public async Task PostSendVerificationEmail_WithInvalidValidModel_ReturnsViewResult()
        {
            // Arrange
            var viewModel = new IndexViewModel();
            controller.ModelState.AddModelError("error", "error");

            // Act
            var result = await controller.SendVerificationEmail(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task PostSendVerificationEmail_WhenUnableToLoadUser_ThrowsApplicationException()
        {
            // Arrange
            var viewModel = new IndexViewModel();
            user = null;
            mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);

            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ApplicationException>(() => controller.SendVerificationEmail(viewModel));
        }
    }
}
