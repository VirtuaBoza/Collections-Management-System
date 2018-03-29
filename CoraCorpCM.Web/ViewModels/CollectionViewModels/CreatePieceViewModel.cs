using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CoraCorpCM.App.Pieces.Commands.CreatePiece;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoraCorpCM.Web.ViewModels.CollectionViewModels
{
    public class CreatePieceViewModel
    {
        public CreatePieceModel Piece { get; set; }

        public IEnumerable<SelectListItem> Media { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Subgenres { get; set; }
        public IEnumerable<SelectListItem> SubjectMatters { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> UnitsOfMeasure { get; set; }
        public IEnumerable<SelectListItem> Artists { get; set; }
        public IEnumerable<SelectListItem> Acquisitions { get; set; }
        public IEnumerable<SelectListItem> PieceSources { get; set; }
        public IEnumerable<SelectListItem> FundingSources { get; set; }
        public IEnumerable<SelectListItem> Collections { get; set; }

        public void Validate(ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(Piece.Title))
            {
                modelState.AddModelError(nameof(Piece.Title), "A title is required.");
            }

            if (Piece.PermanentLocationId < 0 && string.IsNullOrWhiteSpace(Piece.PermanentLocationName))
            {
                modelState.AddModelError(nameof(Piece.PermanentLocationName), "A location requires a name.");
            }

            if (Piece.CurrentLocationId < 0 && string.IsNullOrWhiteSpace(Piece.CurrentLocationName))
            {
                modelState.AddModelError(nameof(Piece.CurrentLocationName), "A location requires a name.");
            }

            if (Piece.ArtistId < 0 && string.IsNullOrWhiteSpace(Piece.ArtistName))
            {
                modelState.AddModelError(nameof(Piece.ArtistName), "An artist requires a name.");
            }

            if (Piece.AcquisitionId < 0 && Piece.AcquisitionDate == null && 
                (Piece.AcquisitionFundingSourceId == null ||
                Piece.AcquisitionFundingSourceId < 0 && string.IsNullOrWhiteSpace(Piece.FundingSourceName)))
            {
                modelState.AddModelError(nameof(Piece.AcquisitionDate), "A new acquisition requires a date or source.");
                modelState.AddModelError(nameof(Piece.AcquisitionFundingSourceId), "A new acquisition requires a date or source.");
            }
        }
    }
}
