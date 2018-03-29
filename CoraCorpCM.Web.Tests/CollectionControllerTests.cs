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

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class CollectionControllerTests
    {
        private CollectionController collectionController;

        [TestInitialize]
        public void SetUp()
        {
            var mockUserManager = AppMockHelper.GetMockUserManager();

            var mockCreatePieceViewModelFactory = new Mock<ICreatePieceViewModelFactory>();
            mockCreatePieceViewModelFactory.Setup(c => c.Create(It.IsAny<string>()))
                .Returns(new CreatePieceViewModel());

            var mockPieceListQuery = new Mock<IGetPieceListQuery>();
            mockPieceListQuery.Setup(q => q.Execute(It.IsAny<string>()))
                .Returns(new List<PieceModel>());

            var mockPieceQuery = new Mock<IGetPieceQuery>();
            mockPieceQuery.Setup(q => q.Execute(It.IsAny<int>()))
                .Returns(new PieceModel());

            collectionController = new CollectionController(
                mockUserManager.Object,
                mockCreatePieceViewModelFactory.Object,
                mockPieceListQuery.Object,
                mockPieceQuery.Object);

            collectionController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = new ClaimsPrincipal() }
            };
        }

        [TestMethod]
        public void GetIndex_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = collectionController.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void GetIndex_ReturnsViewResultWithListOfPieceModel()
        {
            // Arrange

            // Act
            var result = collectionController.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(List<PieceModel>));
        }

        [TestMethod]
        public void GetCreate_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = collectionController.Create();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void GetCreate_ReturnsViewResultWithCreatePieceViewModel()
        {
            // Arrange

            // Act
            var result = collectionController.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
        }

        [TestMethod]
        public void PostCreate_WithValidViewModel_ReturnsRedirectToActionResult()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel { Title = "something" } };

            // Act
            var result = collectionController.Create(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void PostCreate_WithInvalidModelStateFromBinding_ReturnsViewResult()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel { Title = "something" } };
            collectionController.ModelState.AddModelError("key", "error");

            // Act
            var result = collectionController.Create(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void PostCreate_WithInvalidModelStateFromBinding_ReturnsViewResultWithCreatePieceViewModel()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel { Title = "something" } };
            collectionController.ModelState.AddModelError("key", "error");

            // Act
            var result = collectionController.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
        }

        [TestMethod]
        public void PostCreate_WithInvalidCreatePieceViewModel_ReturnsViewResult()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel() };

            // Act
            var result = collectionController.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void PostCreate_WithInvalidCreatePieceViewModel_ReturnsViewResultWithCreatePieceViewModel()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel { Piece = new CreatePieceModel() };

            // Act
            var result = collectionController.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
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
