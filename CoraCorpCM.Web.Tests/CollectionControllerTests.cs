using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CoraCorpCM.App.Interfaces;
using CoraCorpCM.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using System.Threading.Tasks;
using CoraCorpCM.Web.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using CoraCorpCM.App.Tests;
using CoraCorpCM.Web.Services.Collection;
using CoraCorpCM.App.Pieces.Queries;
using CoraCorpCM.App.Pieces.Commands.CreatePiece;
using CoraCorpCM.App.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class CollectionControllerTests
    {
        private CollectionController controller;

        Mock<UserManager<ApplicationUser>> mockUserManager;
        Mock<ICreatePieceViewModelFactory> mockCreatePieceViewModelFactory;
        Mock<IGetPieceListQuery> mockPieceListQuery;
        Mock<IGetPieceQuery> mockPieceQuery;
        Mock<ICreatePieceCommand> mockCreatePieceCommand;
        Mock<ICreatePieceViewModelValidator> mockValidator;

        [TestInitialize]
        public void SetUp()
        {
            mockUserManager = AppMockHelper.GetMockUserManager();
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockUserManager.Setup(u => u.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });

            mockCreatePieceViewModelFactory = new Mock<ICreatePieceViewModelFactory>();
            mockCreatePieceViewModelFactory.Setup(c => c.Create(It.IsAny<string>()))
                .Returns(new CreatePieceViewModel());

            mockPieceListQuery = new Mock<IGetPieceListQuery>();
            mockPieceListQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new List<PieceModel>());

            mockPieceQuery = new Mock<IGetPieceQuery>();
            mockPieceQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new PieceModel());

            mockCreatePieceCommand = new Mock<ICreatePieceCommand>();

            mockValidator = new Mock<ICreatePieceViewModelValidator>();

            controller = new CollectionController(
                mockUserManager.Object,
                mockCreatePieceViewModelFactory.Object,
                mockPieceListQuery.Object,
                mockPieceQuery.Object,
                mockCreatePieceCommand.Object,
                mockValidator.Object);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = new ClaimsPrincipal() }
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
        public async Task GetIndex_ReturnsViewResultWithListOfPieceModel()
        {
            // Arrange

            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(List<PieceModel>));
        }

        [TestMethod]
        public void GetCreate_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void GetCreate_ReturnsViewResultWithCreatePieceViewModel()
        {
            // Arrange

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
        }

        [TestMethod]
        public async Task PostCreate_WithValidViewModel_ReturnsRedirectToActionResult()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel { Title = "something" } };

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public async Task PostCreate_WithInvalidModelStateFromBinding_ReturnsViewResult()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel { Title = "something" } };
            controller.ModelState.AddModelError("key", "error");

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task PostCreate_WithInvalidModelStateFromBinding_ReturnsViewResultWithCreatePieceViewModel()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel { Title = "something" } };
            controller.ModelState.AddModelError("key", "error");

            // Act
            var result = await controller.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
        }

        [TestMethod]
        public async Task PostCreate_WithInvalidCreatePieceViewModel_ReturnsViewResult()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel() };
            controller.ModelState.AddModelError("ErrorKey", "Error Message");

            // Act
            var result = await controller.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task PostCreate_WithInvalidCreatePieceViewModel_ReturnsViewResultWithCreatePieceViewModel()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel() };
            controller.ModelState.AddModelError("ErrorKey", "Error Message");

            // Act
            var result = await controller.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
        }

        [TestMethod]
        public async Task PostCreate_WithValidCreatePieceViewModel_CallsCreatePieceCommand()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel { Title = "something" } };
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            mockCreatePieceCommand.Verify(c => c.Execute(viewModel.Piece));
        }

        //[TestMethod]
        //public void PostCreate_WithValidModelState_AddsPieceToRepository()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    var mockUserManager = MockHelper.GetMockUserManager();
        //    mockUserManager.Setup(um => um.GetUserAsync(null)).Returns(Task.FromResult(new ApplicationUser()));
        //    var mockModelMapper = new Mock<IModelMapper>();
        //    var mockModelValidator = new Mock<IModelValidator>();
        //    var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object, null);
        //    var viewModel = new CreatePieceViewModel();
        //    var piece = new Piece();
        //    mockModelMapper.Setup(m => m.ResolveToPieceModel(viewModel, null)).Returns(piece);

        //    // Act
        //    var result = controller.Create(viewModel);

        //    // Assert
        //    mockRepo.Verify(r => r.Insert(piece));
        //}


        //[TestMethod]
        //public void GetDetails_WithValidId_ReturnsViewResult()
        //{
        //    //Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    mockRepo.Setup(r => r.GetEntity<Piece>(1)).Returns(new Piece());
        //    var controller = new CollectionController(mockRepo.Object, null, null, null, null, null);

        //    //Act
        //    var result = controller.Details(1);

        //    //Assert
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}

        //[TestMethod]
        //public void GetDetails_WithValidId_ReturnsViewResultWithPieceModel()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    mockRepo.Setup(r => r.GetEntity<Piece>(1)).Returns(new Piece());
        //    var controller = new CollectionController(mockRepo.Object, null, null, null, null, null);

        //    // Act
        //    var result = controller.Details(1) as ViewResult;

        //    // Assert
        //    Assert.IsInstanceOfType(result.ViewData.Model, typeof(Piece));
        //}

        //[TestMethod]
        //public void GetDetails_WithNullId_ReturnsNotFoundResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    mockRepo.Setup(r => r.GetEntity<Piece>(1)).Returns(new Piece());
        //    var controller = new CollectionController(mockRepo.Object, null, null, null, null, null);

        //    // Act
        //    var result = controller.Details(null);

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}

        //[TestMethod]
        //public void GetDetails_WithNonMatchingId_ReturnsNotFoundResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    mockRepo.Setup(r => r.GetEntity<Piece>(1)).Returns<Piece>(null);
        //    var controller = new CollectionController(mockRepo.Object, null, null, null, null, null);

        //    // Act
        //    var result = controller.Details(1);

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}
    }
}
