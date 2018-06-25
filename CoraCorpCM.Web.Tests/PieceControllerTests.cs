using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CoraCorpCM.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using System.Threading.Tasks;
using System.Security.Claims;
using CoraCorpCM.Common.Tests;
using CoraCorpCM.Web.Services.Collection;
using CoraCorpCM.Application.Pieces.Queries;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Common.Membership;
using CoraCorpCM.Web.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class PieceControllerTests
    {
        private PieceController controller;

        private Mock<UserManager<ApplicationUser>> mockUserManager;
        private Mock<ICreatePieceViewModelFactory> mockCreatePieceViewModelFactory;
        private Mock<IGetPieceListQuery> mockPieceListQuery;
        private Mock<ICreatePieceCommand> mockCreatePieceCommand;
        private Mock<ICreatePieceMapper> mockMapper;

        [TestInitialize]
        public void SetUp()
        {
            mockUserManager = CommonMockHelper.GetMockUserManager();
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockUserManager.Setup(u => u.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });

            mockCreatePieceViewModelFactory = new Mock<ICreatePieceViewModelFactory>();
            mockCreatePieceViewModelFactory.Setup(c => c.Create(It.IsAny<int>()))
                .Returns(new CreatePieceViewModel());
            mockCreatePieceViewModelFactory.Setup(c => c.Create(It.IsAny<int>(), It.IsAny<CreatePieceViewModel>()))
                .Returns(new CreatePieceViewModel());

            mockPieceListQuery = new Mock<IGetPieceListQuery>();
            mockPieceListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<PieceModel>());

            mockCreatePieceCommand = new Mock<ICreatePieceCommand>();

            mockMapper = new Mock<ICreatePieceMapper>();

            controller = new PieceController(
                mockUserManager.Object,
                mockCreatePieceViewModelFactory.Object,
                mockPieceListQuery.Object,
                mockCreatePieceCommand.Object,
                mockMapper.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext() {User = new ClaimsPrincipal()}
                }
            };

        }

        [TestMethod]
        public async Task Index_ReturnsViewResultWithListOfPieceModel()
        {
            // Arrange
            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result?.ViewData.Model, typeof(List<PieceModel>));
        }

        [TestMethod]
        public async Task Create_OnGet_ReturnsViewResultWithCreatePieceViewModel()
        {
            // Arrange

            // Act
            var result = await controller.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result?.ViewData.Model, typeof(CreatePieceViewModel));
        }

        [TestMethod]
        public async Task Create_OnPost_WithInvalidModel_ReturnsViewResultWithCreatePieceViewModel()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            controller.ModelState.AddModelError("error", "error");

            // Act
            var result = await controller.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result?.ViewData.Model, typeof(CreatePieceViewModel));
        }

        [TestMethod]
        public async Task Create_OnPost_ReturnsRedirectToActionResult()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            mockMapper.SetReturnsDefault(new CreatePieceModel());

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public async Task Create_OnPost_CallsCreatePieceCommand()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockMapper.SetReturnsDefault(new CreatePieceModel());

            // Act
            await controller.Create(viewModel);

            // Assert
            mockCreatePieceCommand.Verify(c => c.Execute(It.IsAny<CreatePieceModel>()), Times.Once);
        }
    }
}
