using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoraCorpCM.Web.Services.Collection
{
    public class CreatePieceViewModelValidator : ICreatePieceViewModelValidator
    {
        public void Validate(CreatePieceViewModel viewModel, ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Piece.Title))
            {
                modelState.AddModelError("Piece.Title", "A title is required.");
            }

            if (viewModel.Piece.PermanentLocationId < 0 && string.IsNullOrWhiteSpace(viewModel.Piece.PermanentLocationName))
            {
                modelState.AddModelError("Piece.PermanentLocationName", "A location requires a name.");
            }

            if (viewModel.Piece.CurrentLocationId < 0 && string.IsNullOrWhiteSpace(viewModel.Piece.CurrentLocationName))
            {
                modelState.AddModelError("Piece.CurrentLocationName", "A location requires a name.");
            }

            if (viewModel.Piece.ArtistId < 0 && string.IsNullOrWhiteSpace(viewModel.Piece.ArtistName))
            {
                modelState.AddModelError("Piece.ArtistName", "An artist requires a name.");
            }

            if (viewModel.Piece.AcquisitionId < 0 && viewModel.Piece.AcquisitionDate == null &&
                (viewModel.Piece.AcquisitionFundingSourceId == null || viewModel.Piece.AcquisitionFundingSourceId < 0 && string.IsNullOrWhiteSpace(viewModel.Piece.FundingSourceName)))
            {
                modelState.AddModelError("Piece.AcquisitionDate", "A new acquisition requires a date or source.");
                modelState.AddModelError("Piece.AcquisitionFundingSourceId", "A new acquisition requires a date or source.");
            }
        }
    }
}
