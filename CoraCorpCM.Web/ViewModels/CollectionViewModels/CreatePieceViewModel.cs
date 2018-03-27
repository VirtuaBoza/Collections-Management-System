using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CoraCorpCM.App.Pieces.Commands.CreatePiece;
using CoraCorpCM.App.Artists.Commands.CreateArtist;
using CoraCorpCM.App.Acquisitions.Commands.CreateAcquisition;
using CoraCorpCM.App.PieceSources.Commands.CreatePieceSource;
using CoraCorpCM.App.FundingSources.Commands.CreateFundingSource;
using CoraCorpCM.App.Media.Commands.CreateMedium;
using CoraCorpCM.App.Genres.Commands.CreateGenre;
using CoraCorpCM.App.Subgenres.Commands.CreateSubgenre;
using CoraCorpCM.App.SubjectMatters.Commands.CreateSubjectMatters;
using CoraCorpCM.App.Locations.Commands.CreateLocation;
using CoraCorpCM.App.Collections.Commands.CreateCollection;

namespace CoraCorpCM.Web.ViewModels.CollectionViewModels
{
    public class CreatePieceViewModel
    {
        public CreatePieceModel Piece { get; set; }

        public CreateMediumModel Medium { get; set; }

        public IEnumerable<SelectListItem> Media { get; set; }

        public CreateGenreModel Genre { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }

        public CreateSubgenreModel Subgenre { get; set; }

        public IEnumerable<SelectListItem> Subgenres { get; set; }

        public CreateSubjectMatterModel SubjectMatter { get; set; }

        public IEnumerable<SelectListItem> SubjectMatters { get; set; }

        public CreateLocationModel PermanentLocation { get; set; }

        public CreateLocationModel CurrentLocation { get; set; }

        public IEnumerable<SelectListItem> Locations { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        public IEnumerable<SelectListItem> UnitsOfMeasure { get; set; }

        public CreateArtistModel Artist { get; set; }

        public IEnumerable<SelectListItem> Artists { get; set; }

        public CreateAcquisitionModel Acquisition { get; set; }

        public IEnumerable<SelectListItem> Acquisitions { get; set; }

        public CreatePieceSourceModel PieceSource { get; set; }

        public IEnumerable<SelectListItem> PieceSources { get; set; }

        public CreateFundingSourceModel FundingSource { get; set; }

        public IEnumerable<SelectListItem> FundingSources { get; set; }

        public CreateCollectionModel Collection { get; set; }

        public IEnumerable<SelectListItem> Collections { get; set; }
    }
}
