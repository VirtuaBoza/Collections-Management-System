using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CoraCorpCM.App.Pieces.Commands.CreatePiece;

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
    }
}
