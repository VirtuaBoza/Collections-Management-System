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

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class CollectionControllerTests
    {
        //[TestMethod]
        //public void GetIndex_ReturnsViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    var mockUserManager = MockHelper.GetMockUserManager();
        //    mockUserManager.Setup(um => um.GetUserAsync(null)).Returns(Task.FromResult(new ApplicationUser()));
        //    var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, null, null, null, null);

        //    // Act
        //    var result = controller.Index();

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}

        //[TestMethod]
        //public void GetIndex_ReturnsViewResultWithIEnumerableOfPieces()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    mockRepo.Setup(r => r.GetEntities<Piece>(null)).Returns(MockHelper.GetTestPieces());
        //    var mockUserManager = MockHelper.GetMockUserManager();
        //    mockUserManager.Setup(um => um.GetUserAsync(null)).Returns(Task.FromResult(new ApplicationUser()));
        //    var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, null, null, null, null);

        //    // Act
        //    var result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.IsInstanceOfType(result.ViewData.Model, typeof(IEnumerable<Piece>));
        //}

        //[TestMethod]
        //public void GetDetails_WithValidId_ReturnsViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    mockRepo.Setup(r => r.GetEntity<Piece>(1)).Returns(new Piece());
        //    var controller = new CollectionController(mockRepo.Object, null, null, null, null, null);

        //    // Act
        //    var result = controller.Details(1);

        //    // Assert
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

        //[TestMethod]
        //public void GetCreate_ReturnsViewResult()
        //{
        //    // Arrange
        //    var mockCreatePieceViewModelFactory = new Mock<ICreatePieceViewModelFactory>();
        //    var controller = new CollectionController(null, null, null, null, null, mockCreatePieceViewModelFactory.Object);
        //    controller.ControllerContext = new ControllerContext()
        //    {
        //        HttpContext = new DefaultHttpContext() { User = new ClaimsPrincipal() }
        //    };

        //    // Act
        //    var result = controller.Create();

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}

        //[TestMethod]
        //public void GetCreate_ReturnsViewResultWithPieceViewModel()
        //{
        //    // Arrange
        //    var mockCreatePieceViewModelFactory = new Mock<ICreatePieceViewModelFactory>();
        //    mockCreatePieceViewModelFactory.Setup(f => f.Create(null)).Returns(new CreatePieceViewModel());
        //    var controller = new CollectionController(null, null, null, null, null, mockCreatePieceViewModelFactory.Object);
        //    controller.ControllerContext = new ControllerContext()
        //    {
        //        HttpContext = new DefaultHttpContext() { User = new ClaimsPrincipal() }
        //    };

        //    // Act
        //    var result = controller.Create() as ViewResult;

        //    // Assert
        //    Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
        //}

        //[TestMethod]
        //public void PostCreate_WithValidViewModel_ReturnsRedirectToActionResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    var mockUserManager = MockHelper.GetMockUserManager();
        //    mockUserManager.Setup(um => um.GetUserAsync(null)).Returns(Task.FromResult(new ApplicationUser()));
        //    var mockModelMapper = new Mock<IModelMapper>();
        //    var viewModel = new CreatePieceViewModel();
        //    mockModelMapper.Setup(mm => mm.ResolveToPieceModel(viewModel, null)).Returns(new Piece());
        //    var mockModelValidator = new Mock<IModelValidator>();
        //    var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object, null);

        //    // Act
        //    var result = controller.Create(viewModel);

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        //}

        //[TestMethod]
        //public void PostCreate_WithInvalidModelState_ReturnsViewResult()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    var mockUserManager = MockHelper.GetMockUserManager();
        //    var mockModelMapper = new Mock<IModelMapper>();
        //    var mockModelValidator = new Mock<IModelValidator>();
        //    var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object, null);
        //    var viewModel = new CreatePieceViewModel();
        //    controller.ModelState.AddModelError("key", "error");

        //    // Act
        //    var result = controller.Create(viewModel);

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}

        //[TestMethod]
        //public void PostCreate_WithInvalidModelState_ReturnsViewResultWithPieceViewModel()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    var mockUserManager = MockHelper.GetMockUserManager();
        //    var mockModelMapper = new Mock<IModelMapper>();
        //    var mockModelValidator = new Mock<IModelValidator>();
        //    var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object, null);
        //    var viewModel = new CreatePieceViewModel();
        //    controller.ModelState.AddModelError("key", "error");

        //    // Act
        //    var result = controller.Create(viewModel) as ViewResult;

        //    // Assert
        //    Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
        //}

        //[TestMethod]
        //public void PostCreate_WithValidModelState_CallsResolveToPieceModelOnModelMapper()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IMuseumRepository>();
        //    var mockUserManager = MockHelper.GetMockUserManager();
        //    mockUserManager.Setup(um => um.GetUserAsync(null)).Returns(Task.FromResult(new ApplicationUser()));
        //    var mockModelMapper = new Mock<IModelMapper>();
        //    var viewModel = new CreatePieceViewModel();
        //    mockModelMapper.Setup(mm => mm.ResolveToPieceModel(viewModel, null)).Returns(new Piece());
        //    var mockModelValidator = new Mock<IModelValidator>();
        //    var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object, null);

        //    // Act
        //    var result = controller.Create(viewModel);

        //    // Assert
        //    mockModelMapper.Verify(r => r.ResolveToPieceModel(viewModel, null));
        //}

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
    }
}
