using CoraCorpCM.Application.Acquisitions.Commands.CreateAcquisition;
using CoraCorpCM.Application.Artists.Commands.CreateArtist;
using CoraCorpCM.Application.Collections.Commands.CreateCollection;
using CoraCorpCM.Application.FundingSources.Commands.CreateFundingSource;
using CoraCorpCM.Application.Genres.Commands.CreateGenre;
using CoraCorpCM.Application.Locations.Commands.CreateLocation;
using CoraCorpCM.Application.Media.Commands.CreateMedium;
using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Application.PieceSources.Commands.CreatePieceSource;
using CoraCorpCM.Application.Subgenres.Commands.CreateSubgenre;
using CoraCorpCM.Application.SubjectMatters.Commands.CreateSubjectMatter;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Web.Services.Collection
{
    public class CreatePieceViewModelMapper : ICreatePieceViewModelMapper
    {
        public CreateAcquisitionModel MapToCreateAcquisitionModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateAcquisitionModel
            {
                Cost = model.AcquisitionCost,
                Date = model.AcquisitionDate,
                FundingSourceId = model.AcquisitionFundingSourceId,
                PieceSourceId = model.AcquisitionPieceSourceId,
                Terms = model.AcquisitionTerms,
                MuseumId = museumId
            };
        }

        public CreateArtistModel MapToCreateArtistModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateArtistModel
            {
                AlsoKnownAs = model.ArtistAlsoKnownAs,
                BirthDate = model.ArtistBirthDate,
                CityOfOrigin = model.ArtistCityOfOrigin,
                CountryOfOriginId = model.ArtistCountryOfOriginId,
                DeathDate = model.ArtistDeathDate,
                Name = model.ArtistName,
                StateOfOrigin = model.ArtistStateOfOrigin,
                MuseumId = museumId
            };
        }

        public CreateCollectionModel MapToCreateCollectionModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateCollectionModel
            {
                Name = model.CollectionName,
                MuseumId = museumId
            };
        }

        public CreateLocationModel MapCurrentLocationToCreateLocationModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateLocationModel
            {
                Address1 = model.CurrentLocationAddress1,
                Address2 = model.CurrentLocationAddress2,
                City = model.CurrentLocationCity,
                CountryId = model.CurrentLocationCountryId,
                Name = model.CurrentLocationName,
                State = model.CurrentLocationState,
                ZipCode = model.CurrentLocationZipCode,
                MuseumId = museumId
            };
        }

        public CreateFundingSourceModel MapToCreateFundingSourceModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateFundingSourceModel
            {
                Name = model.FundingSourceName,
                MuseumId = museumId
            };
        }

        public CreateGenreModel MapToCreateGenreModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateGenreModel
            {
                Name = model.GenreName,
                MuseumId = museumId
            };
        }

        public CreateMediumModel MapToCreateMediumModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateMediumModel
            {
                Name = model.MediumName,
                MuseumId = museumId
            };
        }

        public CreateLocationModel MapPermanentLocationToCreateLocationModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateLocationModel
            {
                Address1 = model.PermanentLocationAddress1,
                Address2 = model.PermanentLocationAddress2,
                City = model.PermanentLocationCity,
                CountryId = model.PermanentLocationCountryId,
                Name = model.PermanentLocationName,
                State = model.PermanentLocationState,
                ZipCode = model.PermanentLocationZipCode,
                MuseumId = museumId
            };
        }

        public CreatePieceModel MapToCreatePieceModel(CreatePieceViewModel model, int museumId, string userId)
        {
            return new CreatePieceModel
            {
                AccessionNumber = model.PieceAccessionNumber,
                AcquisitionId = model.PieceAcquisitionId,
                ArtistId = model.PieceArtistId,
                CityOfOrigin = model.PieceCityOfOrigin,
                CollectionId = model.PieceCollectionId,
                CopyrightOwner = model.PieceCopyrightOwner,
                CopyrightYear = model.PieceCopyrightYear,
                CountryOfOriginId = model.PieceCountryOfOriginId,
                CreationDay = model.PieceCreationDay,
                CreationMonth = model.PieceCreationMonth,
                CreationYear = model.PieceCreationYear,
                CurrentLocationId = model.PieceCurrentLocationId,
                Depth = model.PieceDepth,
                EstimatedValue = model.PieceEstimatedValue,
                GenreId = model.PieceGenreId,
                Height = model.PieceHeight,
                InsuranceAmount = model.PieceInsuranceAmount,
                InsuranceCarrier = model.PieceInsuranceCarrier,
                InsuranceExpirationDate = model.PieceInsuranceExpirationDate,
                InsurancePolicyNumber = model.PieceInsurancePolicyNumber,
                IsArchived = model.PieceIsArchived,
                IsFramed = model.PieceIsFramed,
                MediumId = model.PieceMediumId,
                PermanentLocationId = model.PiecePermanentLocationId,
                StateOfOrigin = model.PieceStateOfOrigin,
                SubgenreId = model.PieceSubgenreId,
                Subject = model.PieceSubject,
                SubjectMatterId = model.PieceSubjectMatterId,
                Title = model.PieceTitle,
                UnitOfMeasureId = model.PieceUnitOfMeasureId,
                Width = model.PieceWidth,
                MuseumId = museumId,
                LastModifiedByUserId = userId
            };
        }

        public CreatePieceSourceModel MapToCreatePieceSourceModel(CreatePieceViewModel model, int museumId)
        {
            return new CreatePieceSourceModel
            {
                Name = model.PieceSourceName,
                MuseumId = museumId
            };
        }

        public CreateSubgenreModel MapToCreateSubgenreModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateSubgenreModel
            {
                Name = model.SubgenreName,
                MuseumId = museumId
            };
        }

        public CreateSubjectMatterModel MapToCreateSubjectMatterModel(CreatePieceViewModel model, int museumId)
        {
            return new CreateSubjectMatterModel
            {
                Name = model.SubgenreName,
                MuseumId = museumId
            };
        }
    }
}
