using CoraCorpCM.Application.Acquisitions.Queries.GetAcquisitionList;
using CoraCorpCM.Application.Artists.Queries.GetArtistList;
using CoraCorpCM.Application.Collections.Queries.GetCollectionList;
using CoraCorpCM.Application.Countries.Queries;
using CoraCorpCM.Application.FundingSources.Queries.GetFundingSourceList;
using CoraCorpCM.Application.Genres.Queries.GetGenreList;
using CoraCorpCM.Application.Locations.Queries.GetLocationList;
using CoraCorpCM.Application.Media.Queries.GetMediumList;
using CoraCorpCM.Application.Museums.Queries;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Application.PieceSources.Queries.GetPieceSourceList;
using CoraCorpCM.Application.Subgenres.Queries.GetSubgenreList;
using CoraCorpCM.Application.SubjectMatters.Queries.GetSubjectMatterList;
using CoraCorpCM.Application.UnitsOfMeasure.Queries.GetUnitsOfMeasureList;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CoraCorpCM.Web.Services.Collection
{
    public class CreatePieceViewModelFactory : ICreatePieceViewModelFactory
    {
        private readonly IGetMuseumForUserIdQuery museumQuery;
        private readonly IGetCountryListQuery countryListQuery;
        private readonly IGetMediumListQuery mediumListQuery;
        private readonly IGetGenreListQuery genreListQuery;
        private readonly IGetSubgenreListQuery subgenreListQuery;
        private readonly IGetSubjectMatterListQuery subjectMatterListQuery;
        private readonly IGetLocationListQuery locationListQuery;
        private readonly IGetUnitOfMeasureListQuery unitOfMeasureListQuery;
        private readonly IGetArtistListQuery artistListQuery;
        private readonly IGetAcquisitionListQuery acquisitionListQuery;
        private readonly IGetPieceSourceListQuery pieceSourceListQuery;
        private readonly IGetFundingSourceListQuery fundingSourceListQuery;
        private readonly IGetCollectionListQuery collectionListQuery;

        public CreatePieceViewModelFactory(
            IGetMuseumForUserIdQuery museumIdQuery,
            IGetCountryListQuery countryListQuery,
            IGetMediumListQuery mediumListQuery,
            IGetGenreListQuery genreListQuery,
            IGetSubgenreListQuery subgenreListQuery,
            IGetSubjectMatterListQuery subjectMatterListQuery,
            IGetLocationListQuery locationListQuery,
            IGetUnitOfMeasureListQuery unitOfMeasureListQuery,
            IGetArtistListQuery artistListQuery,
            IGetAcquisitionListQuery acquisitionListQuery,
            IGetPieceSourceListQuery pieceSourceListQuery,
            IGetFundingSourceListQuery fundingSourceListQuery,
            IGetCollectionListQuery collectionListQuery)
        {
            this.museumQuery = museumIdQuery;
            this.countryListQuery = countryListQuery;
            this.mediumListQuery = mediumListQuery;
            this.genreListQuery = genreListQuery;
            this.subgenreListQuery = subgenreListQuery;
            this.subjectMatterListQuery = subjectMatterListQuery;
            this.locationListQuery = locationListQuery;
            this.unitOfMeasureListQuery = unitOfMeasureListQuery;
            this.artistListQuery = artistListQuery;
            this.acquisitionListQuery = acquisitionListQuery;
            this.pieceSourceListQuery = pieceSourceListQuery;
            this.fundingSourceListQuery = fundingSourceListQuery;
            this.collectionListQuery = collectionListQuery;
        }

        public CreatePieceViewModel Create(string userId)
        {
            var museum = museumQuery.Execute(userId);

            var viewModel = new CreatePieceViewModel
            {
                Piece = new CreatePieceModel()
            };

            var media = mediumListQuery.Execute(museum.Id);
            viewModel.Media = media
                .Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                });

            var genres = genreListQuery.Execute(museum.Id);
            viewModel.Genres = genres
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                });

            var subgenres = subgenreListQuery.Execute(museum.Id);
            viewModel.Subgenres = subgenres
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                });

            var subjectMatters = subjectMatterListQuery.Execute(museum.Id);
            viewModel.SubjectMatters = subjectMatters
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                });

            var locations = locationListQuery.Execute(museum.Id);
            viewModel.Locations = locations
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
                });

            var countries = countryListQuery.Execute();
            viewModel.Countries = countries
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            var unitsOfMeasure = unitOfMeasureListQuery.Execute();
            viewModel.UnitsOfMeasure = unitsOfMeasure
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.Abbreviation
                });

            var artists = artistListQuery.Execute(museum.Id);
            viewModel.Artists = artists
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = string.IsNullOrWhiteSpace(a.AlsoKnownAs) ? a.Name : string.Format("{0} aka \"{1}\"",a.Name, a.AlsoKnownAs)
                });

            var acquisitions = acquisitionListQuery.Execute(museum.Id);
            viewModel.Acquisitions = acquisitions
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Date?.ToString("MM/dd/yyyy") + " " + a.PieceSource
                });

            var pieceSources = pieceSourceListQuery.Execute(museum.Id);
            viewModel.PieceSources = pieceSources
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                });

            var fundingSources = fundingSourceListQuery.Execute(museum.Id);
            viewModel.FundingSources = fundingSources
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name
                });

            var collections = collectionListQuery.Execute(museum.Id);
            viewModel.Collections = collections
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

            return viewModel;
        }
    }
}
