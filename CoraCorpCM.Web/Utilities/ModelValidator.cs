using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoraCorpCM.Web.Utilities
{
    public class ModelValidator : IModelValidator
    {
        public bool Validate(ModelStateDictionary modelState, CreatePieceViewModel pieceViewModel)
        {
            if (!ValidateArtist(pieceViewModel))
            {
                modelState.AddModelError("ArtistName", "New Artist must have a name.");
            }

            if (!ValidateAcquisition(pieceViewModel))
            {
                modelState.AddModelError("AcquisitionDate", "New Acquisition must have either date or source.");
                modelState.AddModelError("PieceSourceId", "New Acquisition must have either date or source.");
            }

            if (!ValidatePermanentLocation(pieceViewModel))
            {
                modelState.AddModelError("PermanentLocationName", "New locations must have a name.");
            }

            if (!ValidateCurrentLocation(pieceViewModel))
            {
                modelState.AddModelError("CurrentLocationName", "New locations must have a name.");
            }

            return modelState.IsValid;
        }

        private bool ValidateCurrentLocation(CreatePieceViewModel viewModel)
        {
            if (viewModel.CurrentLocationId == "-2")
            {
                viewModel.CurrentLocationId = viewModel.PermanentLocationId;
                viewModel.CurrentLocationName = viewModel.PermanentLocationName;
                viewModel.CurrentAddress1 = viewModel.PermanentAddress1;
                viewModel.CurrentAddress2 = viewModel.PermanentAddress2;
                viewModel.CurrentCity = viewModel.PermanentCity;
                viewModel.CurrentState = viewModel.PermanentState;
                viewModel.CurrentZipCode = viewModel.PermanentZipCode;
                viewModel.CurrentCountryId = viewModel.PermanentCountryId;
            }

            if (viewModel.CurrentLocationId == "-1" && string.IsNullOrWhiteSpace(viewModel.CurrentLocationName))
            {
                return false;
            }

            return true;
        }

        private bool ValidatePermanentLocation(CreatePieceViewModel viewModel)
        {
            if (viewModel.PermanentLocationId == "-1" && string.IsNullOrWhiteSpace(viewModel.PermanentLocationName))
            {
                return false;
            }

            return true;
        }

        private bool ValidateArtist(CreatePieceViewModel viewModel)
        {
            if (viewModel.ArtistId == "-1" && string.IsNullOrWhiteSpace(viewModel.ArtistName))
            {
                return false;
            }

            return true;
        }

        private bool ValidateAcquisition(CreatePieceViewModel viewModel)
        {
            if (viewModel.AcquisitionId == "-1" && string.IsNullOrWhiteSpace(viewModel.AcquisitionDate) &&
                (string.IsNullOrWhiteSpace(viewModel.PieceSourceId) ||
                 viewModel.PieceSourceId == "-1" && string.IsNullOrWhiteSpace(viewModel.PieceSourceName)))
            {
                return false;
            }

            return true;
        }
    }
}
