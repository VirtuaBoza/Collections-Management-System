using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CoraCorpCM.Data;
using CoraCorpCM.Domain.Models;
using CoraCorpCM.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CoraCorpCM.Web.Utilities;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class CollectionControllerTests
    {
        [TestMethod]
        public void GetIndex_ReturnsViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var mockUserManager = MockHelper.GetMockUserManager();
            var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, null, null, null);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void GetIndex_ReturnsViewResultWithIEnumerableOfPieces()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntities<Piece>(null)).Returns(MockHelper.GetTestPieces());
            var mockUserManager = MockHelper.GetMockUserManager();
            var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, null, null, null);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(IEnumerable<Piece>));
        }

        [TestMethod]
        public void GetDetails_WithValidId_ReturnsViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Piece>(1)).Returns(new Piece());
            var controller = new CollectionController(mockRepo.Object, null, null, null, null);

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void GetDetails_WithValidId_ReturnsViewResultWithPieceModel()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Piece>(1)).Returns(new Piece());
            var controller = new CollectionController(mockRepo.Object, null, null, null, null);

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(Piece));
        }

        [TestMethod]
        public void GetDetails_WithNullId_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Piece>(1)).Returns(new Piece());
            var controller = new CollectionController(mockRepo.Object, null, null, null, null);

            // Act
            var result = controller.Details(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetDetails_WithNonMatchingId_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            mockRepo.Setup(r => r.GetEntity<Piece>(1)).Returns<Piece>(null);
            var controller = new CollectionController(mockRepo.Object, null, null, null, null);

            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetCreate_ReturnsViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var mockUserManager = MockHelper.GetMockUserManager();
            var mockSelectListMaker = new Mock<SelectListMaker>();
            var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, null, mockSelectListMaker.Object, null);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void GetCreate_ReturnsViewResultWithPieceViewModel()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var mockUserManager = MockHelper.GetMockUserManager();
            var mockSelectListMaker = new Mock<SelectListMaker>();
            var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, null, mockSelectListMaker.Object, null);

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(PieceViewModel));
        }

        [TestMethod]
        public void PostCreate_WithValidViewModel_ReturnsRedirectToActionResult()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var mockUserManager = MockHelper.GetMockUserManager();
            var mockModelMapper = new Mock<IModelMapper>();
            var mockModelValidator = new Mock<IModelValidator>();
            var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object);
            var viewModel = new PieceViewModel();

            // Act
            var result = controller.Create(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void PostCreate_WithInvalidModelState_ReturnsViewResult()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var mockUserManager = MockHelper.GetMockUserManager();
            var mockModelMapper = new Mock<IModelMapper>();
            var mockModelValidator = new Mock<IModelValidator>();
            var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object);
            var viewModel = new PieceViewModel();
            controller.ModelState.AddModelError("key", "error");

            // Act
            var result = controller.Create(viewModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void PostCreate_WithInvalidModelState_ReturnsViewResultWithPieceViewModel()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var mockUserManager = MockHelper.GetMockUserManager();
            var mockModelMapper = new Mock<IModelMapper>();
            var mockModelValidator = new Mock<IModelValidator>();
            var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object);
            var viewModel = new PieceViewModel();
            controller.ModelState.AddModelError("key", "error");

            // Act
            var result = controller.Create(viewModel) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(PieceViewModel));
        }

        [TestMethod]
        public void PostCreate_WithValidModelState_CallsResolveToPieceModelOnModelMapper()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var mockUserManager = MockHelper.GetMockUserManager();
            var mockModelMapper = new Mock<IModelMapper>();
            var mockModelValidator = new Mock<IModelValidator>();
            var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object);
            var viewModel = new PieceViewModel();

            // Act
            var result = controller.Create(viewModel);

            // Assert
            mockModelMapper.Verify(r => r.ResolveToPieceModel(viewModel, null));
        }

        [TestMethod]
        public void PostCreate_WithValidModelState_AddsPieceToRepository()
        {
            // Arrange
            var mockRepo = new Mock<IMuseumRepository>();
            var mockUserManager = MockHelper.GetMockUserManager();
            var mockModelMapper = new Mock<IModelMapper>();
            var mockModelValidator = new Mock<IModelValidator>();
            var controller = new CollectionController(mockRepo.Object, mockUserManager.Object, mockModelMapper.Object, null, mockModelValidator.Object);
            var viewModel = new PieceViewModel();
            var piece = new Piece();
            mockModelMapper.Setup(m => m.ResolveToPieceModel(viewModel, null)).Returns(piece);

            // Act
            var result = controller.Create(viewModel);

            // Assert
            mockRepo.Verify(r => r.Insert(piece));
        }
    }
}
