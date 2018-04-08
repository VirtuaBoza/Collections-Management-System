using System.Linq;
using CoraCorpCM.App.Acquisitions.Commands.CreateAcquisition.Factory;
using CoraCorpCM.App.Artists.Commands.CreateArtist.Factory;
using CoraCorpCM.App.Collections.Commands.CreateCollection.Factory;
using CoraCorpCM.App.FundingSources.Commands.CreateFundingSource.Factory;
using CoraCorpCM.App.Genres.Commands.CreateGenre.Factory;
using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.App.Locations.Commands.CreateLocation.Factory;
using CoraCorpCM.App.Media.Commands.CreateMedium.Factory;
using CoraCorpCM.App.Pieces.Commands.CreatePiece.Factory;
using CoraCorpCM.App.Pieces.Commands.CreatePiece.Repository;
using CoraCorpCM.App.PieceSources.Commands.CreatePieceSource.Factory;
using CoraCorpCM.App.Subgenres.Commands.CreateSubgenre.Factory;
using CoraCorpCM.App.SubjectMatters.Commands.CreateSubjectMatters.Factory;
using CoraCorpCM.Common;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Pieces.Commands.CreatePiece
{
    public class CreatePieceCommand : ICreatePieceCommand
    {
        private readonly IPieceRepositoryFacade repository;
        private readonly IDateService dateService;
        private readonly IPieceFactory pieceFactory;
        private readonly IArtistFactory artistFactory;
        private readonly IMediumFactory mediumFactory;
        private readonly IGenreFactory genreFactory;
        private readonly ISubgenreFactory subgenreFactory;
        private readonly ISubjectMatterFactory subjectMatterFactory;
        private readonly IAcquisitionFactory acquisitionFactory;
        private readonly IFundingSourceFactory fundingSourceFactory;
        private readonly IPieceSourceFactory pieceSourceFactory;
        private readonly ILocationFactory locationFactory;
        private readonly ICollectionFactory collectionFactory;
        private readonly IUnitOfWork unitOfWork;

        public CreatePieceCommand(
            IPieceRepositoryFacade repository,
            IDateService dateService,
            IPieceFactory pieceFactory,
            IArtistFactory artistFactory,
            IMediumFactory mediumFactory,
            IGenreFactory genreFactory,
            ISubgenreFactory subgenreFactory,
            ISubjectMatterFactory subjectMatterFactory,
            IAcquisitionFactory acquisitionFactory,
            IFundingSourceFactory fundingSourceFactory,
            IPieceSourceFactory pieceSourceFactory,
            ILocationFactory locationFactory,
            ICollectionFactory collectionFactory,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.dateService = dateService;
            this.pieceFactory = pieceFactory;
            this.artistFactory = artistFactory;
            this.mediumFactory = mediumFactory;
            this.genreFactory = genreFactory;
            this.subgenreFactory = subgenreFactory;
            this.subjectMatterFactory = subjectMatterFactory;
            this.acquisitionFactory = acquisitionFactory;
            this.fundingSourceFactory = fundingSourceFactory;
            this.pieceSourceFactory = pieceSourceFactory;
            this.locationFactory = locationFactory;
            this.collectionFactory = collectionFactory;
            this.unitOfWork = unitOfWork;
        }

        public void Execute(CreatePieceModel model)
        {
            Country countryOfOrigin = null;
            if (model.CountryOfOriginId.HasValue)
            {
                countryOfOrigin = repository.GetCountry(model.CountryOfOriginId.Value);
            }

            var museum = repository.GetMuseum(model.MuseumId);
            var unitOfMeasure = repository.GetUnitOfMeasure(model.UnitOfMeasureId);
            var artist = GetArtist(model);
            var medium = GetMedium(model);
            var genre = GetGenre(model);
            var subgenre = GetSubgenre(model);
            var subjectMatter = GetSubjectMatter(model);
            var acquisition = GetAcquisition(model);
            var currentLocation = GetCurrentLocation(model);
            var permanentLocation = GetPermanentLocation(model);
            var collection = GetCollection(model);
            var timeStamp = dateService.GetCurrentServerTime();

            var piece = pieceFactory.Create(
                ++museum.RecordCount,
                model.Title,
                model.AccessionNumber,
                model.CreationDay,
                model.CreationMonth,
                model.CreationYear,
                countryOfOrigin,
                model.StateOfOrigin,
                model.CityOfOrigin,
                model.Height,
                model.Width,
                model.Depth,
                unitOfMeasure,
                model.EstimatedValue,
                model.Subject,
                model.CopyrightYear,
                model.CopyrightOwner,
                model.InsurancePolicyNumber,
                model.InsuranceExpirationDate,
                model.InsuranceAmount,
                model.InsuranceCarrier,
                model.IsFramed,
                model.IsArchived,
                artist,
                medium,
                genre,
                subgenre,
                subjectMatter,
                acquisition,
                currentLocation,
                permanentLocation,
                collection,
                model.LastModifiedByUserId,
                timeStamp,
                model.MuseumId);

            repository.AddPiece(piece);

            unitOfWork.Save();
        }

        private Artist GetArtist(CreatePieceModel model)
        {
            Artist artist = null;
            if (model.ArtistId >= 0)
            {
                artist = repository.GetArtist(model.ArtistId.Value);
            }
            else if (model.ArtistId < 0 && !string.IsNullOrWhiteSpace(model.ArtistName))
            {
                Country artistCountryOfOrigin = null;
                if (model.ArtistCountryOfOriginId.HasValue)
                {
                    artistCountryOfOrigin = repository.GetCountry(model.ArtistCountryOfOriginId.Value);
                }

                artist = artistFactory.Create(
                    model.ArtistName, 
                    model.ArtistAlsoKnownAs, 
                    model.ArtistCityOfOrigin, 
                    model.ArtistStateOfOrigin, 
                    artistCountryOfOrigin, 
                    model.ArtistBirthDate, 
                    model.ArtistDeathDate, 
                    model.MuseumId);

                repository.AddArtist(artist);
            }

            return artist;
        }

        private Medium GetMedium(CreatePieceModel model)
        {
            Medium medium = null;
            if (model.MediumId >= 0)
            {
                medium = repository.GetMedium(model.MediumId.Value);
            }
            else if (model.MediumId < 0 && !string.IsNullOrWhiteSpace(model.MediumName))
            {
                medium = repository.GetMedia().SingleOrDefault(m => m.Name == model.MediumName && m.MuseumId == model.MuseumId);
                if (medium == null)
                {
                    medium = mediumFactory.Create(model.MediumName, model.MuseumId);

                    repository.AddMedium(medium);
                }
            }

            return medium;
        }

        private Genre GetGenre(CreatePieceModel model)
        {
            Genre genre = null;
            if (model.GenreId >= 0)
            {
                genre = repository.GetGenre(model.GenreId.Value);
            }
            else if (model.GenreId < 0 && !string.IsNullOrWhiteSpace(model.GenreName))
            {
                genre = repository.GetGenres().SingleOrDefault(g => g.Name == model.GenreName && g.MuseumId == model.MuseumId);
                if (genre == null)
                {
                    genre = genreFactory.Create(model.GenreName, model.MuseumId);

                    repository.AddGenre(genre);
                }
            }

            return genre;
        }

        private Subgenre GetSubgenre(CreatePieceModel model)
        {
            Subgenre subgenre = null;
            if (model.SubgenreId >= 0)
            {
                subgenre = repository.GetSubgenre(model.SubgenreId.Value);
            }
            else if (model.SubgenreId < 0 && !string.IsNullOrWhiteSpace(model.SubgenreName))
            {
                subgenre = repository.GetSubgenres().SingleOrDefault(g => g.Name == model.SubgenreName && g.MuseumId == model.MuseumId);
                if (subgenre == null)
                {
                    subgenre = subgenreFactory.Create(model.SubgenreName, model.MuseumId);

                    repository.AddSubgenre(subgenre);
                }
            }

            return subgenre;
        }

        private SubjectMatter GetSubjectMatter(CreatePieceModel model)
        {
            SubjectMatter subjectMatter = null;
            if (model.SubjectMatterId >= 0)
            {
                subjectMatter = repository.GetSubjectMatter(model.SubjectMatterId.Value);
            }
            else if (model.SubjectMatterId < 0 && !string.IsNullOrWhiteSpace(model.SubjectMatterName))
            {
                subjectMatter = repository.GetSubjectMatters().SingleOrDefault(g => g.Name == model.SubjectMatterName && g.MuseumId == model.MuseumId);
                if (subjectMatter == null)
                {
                    subjectMatter = subjectMatterFactory.Create(model.SubjectMatterName, model.MuseumId);

                    repository.AddSubjectMatter(subjectMatter);
                }
            }

            return subjectMatter;
        }

        private Acquisition GetAcquisition(CreatePieceModel model)
        {
            Acquisition acquisition = null;
            if (model.AcquisitionId >= 0)
            {
                acquisition = repository.GetAcquisition(model.AcquisitionId.Value);
            }
            else if (model.AcquisitionId < 0 && (model.AcquisitionDate.HasValue || 
                (model.AcquisitionFundingSourceId > 0 || 
                (model.AcquisitionFundingSourceId < 0 && !string.IsNullOrWhiteSpace(model.FundingSourceName)))))
            {
                acquisition = acquisitionFactory.Create(
                    model.AcquisitionDate, 
                    model.AcquisitionCost, 
                    model.AcquisitionTerms, 
                    GetFundingSource(model), 
                    GetPieceSource(model),
                    model.MuseumId);

                repository.AddAcquisition(acquisition);
            }

            return acquisition;
        }

        private FundingSource GetFundingSource(CreatePieceModel model)
        {
            FundingSource fundingSource = null;
            if (model.AcquisitionFundingSourceId >= 0)
            {
                fundingSource = repository.GetFundingSource(model.AcquisitionFundingSourceId.Value);
            }
            else if (model.AcquisitionFundingSourceId < 0 && !string.IsNullOrWhiteSpace(model.FundingSourceName))
            {
                fundingSource = repository.GetFundingSources().SingleOrDefault(f => f.Name == model.FundingSourceName && f.MuseumId == model.MuseumId);
                if (fundingSource == null)
                {
                    fundingSource = fundingSourceFactory.Create(model.FundingSourceName, model.MuseumId);

                    repository.AddFundingSource(fundingSource);
                }
            }

            return fundingSource;
        }

        private PieceSource GetPieceSource(CreatePieceModel model)
        {
            PieceSource pieceSource = null;
            if (model.AcquisitionPieceSourceId >= 0)
            {
                pieceSource = repository.GetPieceSource(model.AcquisitionPieceSourceId.Value);
            }
            else if (model.AcquisitionPieceSourceId < 0 && !string.IsNullOrWhiteSpace(model.PieceSourceName))
            {
                pieceSource = repository.GetPieceSources().SingleOrDefault(f => f.Name == model.PieceSourceName && f.MuseumId == model.MuseumId);
                if (pieceSource == null)
                {
                    pieceSource = pieceSourceFactory.Create(model.PieceSourceName, model.MuseumId);

                    repository.AddPieceSource(pieceSource);
                }
            }

            return pieceSource;
        }

        private Location GetCurrentLocation(CreatePieceModel model)
        {
            Location location = null;
            if (model.CurrentLocationId >= 0)
            {
                location = repository.GetLocation(model.CurrentLocationId.Value);
            }
            else if (model.CurrentLocationId < 0 && !string.IsNullOrWhiteSpace(model.CurrentLocationName))
            {
                Country country = null;
                if (model.CurrentLocationCountryId.HasValue)
                {
                    country = repository.GetCountry(model.CurrentLocationCountryId.Value);
                }

                location = locationFactory.Create(
                    model.CurrentLocationName,
                    model.CurrentLocationAddress1,
                    model.CurrentLocationAddress2,
                    model.CurrentLocationCity,
                    model.CurrentLocationState,
                    model.CurrentLocationZipCode,
                    country,
                    model.MuseumId);

                repository.AddLocation(location);
            }

            return location;
        }

        private Location GetPermanentLocation(CreatePieceModel model)
        {
            Location location = null;
            if (model.PermanentLocationId >= 0)
            {
                location = repository.GetLocation(model.PermanentLocationId.Value);
            }
            else if (model.PermanentLocationId < 0 && !string.IsNullOrWhiteSpace(model.PermanentLocationName))
            {
                Country country = null;
                if (model.PermanentLocationCountryId.HasValue)
                {
                    country = repository.GetCountry(model.PermanentLocationCountryId.Value);
                }

                location = locationFactory.Create(
                    model.PermanentLocationName,
                    model.PermanentLocationAddress1,
                    model.PermanentLocationAddress2,
                    model.PermanentLocationCity,
                    model.PermanentLocationState,
                    model.PermanentLocationZipCode,
                    country,
                    model.MuseumId);

                repository.AddLocation(location);
            }

            return location;
        }

        private Collection GetCollection(CreatePieceModel model)
        {
            Collection collection = null;
            if (model.CollectionId >= 0)
            {
                collection = repository.GetCollection(model.CollectionId.Value);
            }
            else if (model.CollectionId < 0 && !string.IsNullOrWhiteSpace(model.CollectionName))
            {
                collection = repository.GetCollections().SingleOrDefault(g => g.Name == model.CollectionName && g.MuseumId == model.MuseumId);
                if (collection == null)
                {
                    collection = collectionFactory.Create(model.CollectionName, model.MuseumId);

                    repository.AddCollection(collection);
                }
            }

            return collection;
        }
    }
}
