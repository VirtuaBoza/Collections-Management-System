using System.Linq;
using CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition.Factory;
using CoraCorpCM.Application.Artists.Commands.CreateArtist.Factory;
using CoraCorpCM.Application.Collections.Commands.CreateCollection.Factory;
using CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource.Factory;
using CoraCorpCM.Application.Genres.Commands.CreateGenre.Factory;
using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Locations.Commands.CreateLocation.Factory;
using CoraCorpCM.Application.Media.Commands.CreateMedium.Factory;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece.Factory;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece.Repository;
using CoraCorpCM.Application.PieceSources.Commands.CreatePieceSource.Factory;
using CoraCorpCM.Application.Subgenres.Commands.CreateSubgenre.Factory;
using CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter.Factory;
using CoraCorpCM.Common;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Pieces.Commands.CreatePiece
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

        public int Execute(CreatePieceModel model)
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

            return piece.Id;
        }

        private Artist GetArtist(CreatePieceModel model)
        {
            if (model.ArtistId >= 0)
            {
                return repository.GetArtist(model.ArtistId.Value);
            }

            return null;
        }

        private Medium GetMedium(CreatePieceModel model)
        {
            if (model.MediumId >= 0)
            {
                return repository.GetMedium(model.MediumId.Value);
            }

            return null;
        }

        private Genre GetGenre(CreatePieceModel model)
        {
            if (model.GenreId >= 0)
            {
                return repository.GetGenre(model.GenreId.Value);
            }

            return null;
        }

        private Subgenre GetSubgenre(CreatePieceModel model)
        {
            if (model.SubgenreId >= 0)
            {
                return repository.GetSubgenre(model.SubgenreId.Value);
            }

            return null;
        }

        private SubjectMatter GetSubjectMatter(CreatePieceModel model)
        {
            if (model.SubjectMatterId >= 0)
            {
                return repository.GetSubjectMatter(model.SubjectMatterId.Value);
            }

            return null;
        }

        private Acquisition GetAcquisition(CreatePieceModel model)
        {
            if (model.AcquisitionId >= 0)
            {
                return repository.GetAcquisition(model.AcquisitionId.Value);
            }

            return null;
        }

        private Location GetCurrentLocation(CreatePieceModel model)
        {
            if (model.CurrentLocationId >= 0)
            {
                return repository.GetLocation(model.CurrentLocationId.Value);
            }

            return null;
        }

        private Location GetPermanentLocation(CreatePieceModel model)
        {
            if (model.PermanentLocationId >= 0)
            {
                return repository.GetLocation(model.PermanentLocationId.Value);
            }

            return null;
        }

        private Collection GetCollection(CreatePieceModel model)
        {
            if (model.CollectionId >= 0)
            {
                return repository.GetCollection(model.CollectionId.Value);
            }

            return null;
        }
    }
}
