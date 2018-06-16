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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition;
using CoraCorpCM.Application.Artists.Commands.CreateArtist;
using CoraCorpCM.Application.Collections.Commands.CreateCollection;
using CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource;
using CoraCorpCM.Application.Genres.Commands.CreateGenre;
using CoraCorpCM.Application.Locations.Commands.CreateLocation;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class CollectionControllerTests
    {
        private CollectionController controller;

        Mock<UserManager<ApplicationUser>> mockUserManager;
        Mock<ICreatePieceViewModelFactory> mockCreatePieceViewModelFactory;
        Mock<IGetPieceListQuery> mockPieceListQuery;
        Mock<ICreatePieceCommandFacade> mockCreateCommand;
        Mock<ICreatePieceViewModelMapper> mockMapper;

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

            mockCreateCommand = new Mock<ICreatePieceCommandFacade>();

            mockMapper = new Mock<ICreatePieceViewModelMapper>();

            controller = new CollectionController(
                mockUserManager.Object,
                mockCreatePieceViewModelFactory.Object,
                mockPieceListQuery.Object,
                mockCreateCommand.Object,
                mockMapper.Object);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = new ClaimsPrincipal() }
            };
        }

        [TestMethod]
        public async Task Index_ReturnsViewResultWithListOfPieceModel()
        {
            // Arrange
            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(List<PieceModel>));
        }

        [TestMethod]
        public async Task Create_OnGet_ReturnsViewResultWithCreatePieceViewModel()
        {
            // Arrange

            // Act
            var result = await controller.Create() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
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
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(CreatePieceViewModel));
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
            var result = await controller.Create(viewModel);

            // Assert
            mockCreateCommand.Verify(c => c.Execute(It.IsAny<CreatePieceModel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_OnPost_WithCreateAcquisitionFlag_CallsCreateAcquisitionCommand()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            viewModel.PieceAcquisitionId = -1;
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockMapper.SetReturnsDefault(new CreatePieceModel());

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            mockCreateCommand.Verify(c => c.Execute(It.IsAny<CreateAcquisitionModel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_OnPost_WithCreateArtistFlag_CallsCreateArtistCommand()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            viewModel.PieceArtistId = -1;
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockMapper.SetReturnsDefault(new CreatePieceModel());

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            mockCreateCommand.Verify(c => c.Execute(It.IsAny<CreateArtistModel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_OnPost_WithCreateCollectionFlag_CallsCreateCollectionCommand()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            viewModel.PieceCollectionId = -1;
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockMapper.SetReturnsDefault(new CreatePieceModel());

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            mockCreateCommand.Verify(c => c.Execute(It.IsAny<CreateCollectionModel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_OnPost_WithCreateFundingSourceFlag_CallsCreateFundingSourceCommand()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            viewModel.AcquisitionFundingSourceId = -1;
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockMapper.SetReturnsDefault(new CreatePieceModel());
            mockMapper.SetReturnsDefault(new CreateAcquisitionModel());

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            mockCreateCommand.Verify(c => c.Execute(It.IsAny<CreateFundingSourceModel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_OnPost_WithCreateGenreFlag_CallsCreateGenreCommand()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            viewModel.PieceGenreId = -1;
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockMapper.SetReturnsDefault(new CreatePieceModel());

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            mockCreateCommand.Verify(c => c.Execute(It.IsAny<CreateGenreModel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_OnPost_WithCreateCurrentLocationFlag_CallsCreateLocationCommand()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            viewModel.PieceCurrentLocationId = -1;
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockMapper.SetReturnsDefault(new CreatePieceModel());

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            mockCreateCommand.Verify(c => c.Execute(It.IsAny<CreateLocationModel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_OnPost_WithCreatePermanentLocationFlag_CallsCreateLocationCommand()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            viewModel.PiecePermanentLocationId = -1;
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { MuseumId = 1 });
            mockMapper.SetReturnsDefault(new CreatePieceModel());

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            mockCreateCommand.Verify(c => c.Execute(It.IsAny<CreateLocationModel>()), Times.Once);
        }

        [TestMethod]
        public async Task Create_OnPost_WithCreateCurrentLocationSameAsPermanentFlag_SetsCurrentLocationEqualToPermanentLocation()
        {
            // Arrange
            var viewModel = new CreatePieceViewModel();
            viewModel.PieceCurrentLocationId = 5;
            viewModel.PiecePermanentLocationId = -2;
            var museumId = 1;
            var userId = "2";
            var createPieceModel = new CreatePieceModel();
            mockUserManager.Setup(u => u.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new ApplicationUser { Id = userId, MuseumId = museumId });
            mockMapper.Setup(m => m.MapToCreatePieceModel(viewModel, museumId, userId)).Returns(createPieceModel);
            mockMapper.SetReturnsDefault(new CreatePieceModel());

            // Act
            var result = await controller.Create(viewModel);

            // Assert
            Assert.AreEqual(viewModel.PieceCurrentLocationId, createPieceModel.PermanentLocationId);
        }
    }
}
