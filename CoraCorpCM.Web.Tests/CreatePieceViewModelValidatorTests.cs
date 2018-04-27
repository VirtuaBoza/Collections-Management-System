using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Web.Services.Collection;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoraCorpCM.Web.Tests
{
    [TestClass]
    public class CreatePieceViewModelValidatorTests
    {
        CreatePieceViewModel viewModel;
        ModelStateDictionary modelState;

        CreatePieceViewModelValidator validator;

        [TestInitialize]
        public void SetUp()
        {
            viewModel = new CreatePieceViewModel
            {
                Piece = new CreatePieceModel(),
            };
            modelState = new ModelStateDictionary();

            validator = new CreatePieceViewModelValidator();
        }

        [TestMethod]
        public void Validate_WithValidState_AddsNoErrorsToModelState()
        {
            // Arrange
            viewModel.Piece.Title = "title";

            // Act
            validator.Validate(viewModel, modelState);

            // Assert
            Assert.AreEqual(0, modelState.Count);
        }

        [TestMethod]
        public void Validate_WithMissingTitle_AddsErrorToModelState()
        {
            // Arrange

            // Act
            validator.Validate(viewModel, modelState);

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
            validator.Validate(viewModel, modelState);

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
            validator.Validate(viewModel, modelState);

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
            validator.Validate(viewModel, modelState);

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
            validator.Validate(viewModel, modelState);

            // Assert
            Assert.AreEqual(2, modelState.Count);
        }
    }
}
