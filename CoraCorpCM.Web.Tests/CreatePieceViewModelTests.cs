using CoraCorpCM.App.Acquisitions.Commands.CreateAcquisition;
using CoraCorpCM.App.Artists.Commands.CreateArtist;
using CoraCorpCM.App.Collections.Commands.CreateCollection;
using CoraCorpCM.App.FundingSources.Commands.CreateFundingSource;
using CoraCorpCM.App.Genres.Commands.CreateGenre;
using CoraCorpCM.App.Locations.Commands.CreateLocation;
using CoraCorpCM.App.Media.Commands.CreateMedium;
using CoraCorpCM.App.Pieces.Commands.CreatePiece;
using CoraCorpCM.App.PieceSources.Commands.CreatePieceSource;
using CoraCorpCM.App.Subgenres.Commands.CreateSubgenre;
using CoraCorpCM.App.SubjectMatters.Commands.CreateSubjectMatters;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class CreatePieceViewModelTests
    {
        CreatePieceViewModel viewModel;
        ModelStateDictionary modelState;

        [TestInitialize]
        public void SetUp()
        {
            viewModel = new CreatePieceViewModel
            {
                Piece = new CreatePieceModel(),
            };
            modelState = new ModelStateDictionary();
        }

        [TestMethod]
        public void Validate_WithValidState_AddsNoErrorsToModelState()
        {
            // Arrange
            viewModel.Piece.Title = "title";

            // Act
            viewModel.Validate(modelState);

            // Assert
            Assert.AreEqual(0, modelState.Count);
        }

        [TestMethod]
        public void Validate_WithMissingTitle_AddsErrorToModelState()
        {
            // Arrange

            // Act
            viewModel.Validate(modelState);

            // Assert
            Assert.AreEqual(1, modelState.Count);
        }

        [TestMethod]
        public void Validate_WithNoNameForNewPermanentLocation_AddsErrorToModelState()
        {
            // Arrange
            viewModel.Piece.Title = "title";
            viewModel.Piece.PermanentLocationId = -1;

            // Act
            viewModel.Validate(modelState);

            // Assert
            Assert.AreEqual(1, modelState.Count);
        }

        [TestMethod]
        public void Validate_WithNoNameForNewCurrentLocation_AddsErrorToModelState()
        {
            // Arrange
            viewModel.Piece.Title = "title";
            viewModel.Piece.CurrentLocationId = -1;

            // Act
            viewModel.Validate(modelState);

            // Assert
            Assert.AreEqual(1, modelState.Count);
        }

        [TestMethod]
        public void Validate_WithNoNameForNewArtist_AddsErrorToModelState()
        {
            // Arrange
            viewModel.Piece.Title = "title";
            viewModel.Piece.ArtistId = -1;

            // Act
            viewModel.Validate(modelState);

            // Assert
            Assert.AreEqual(1, modelState.Count);
        }

        [TestMethod]
        public void Validate_WithNoDateOrSourceForNewAcquisition_AddsErrorsToModelState()
        {
            // Arrange
            viewModel.Piece.Title = "title";
            viewModel.Piece.AcquisitionId = -1;

            // Act
            viewModel.Validate(modelState);

            // Assert
            Assert.AreEqual(2, modelState.Count);
        }
    }
}
