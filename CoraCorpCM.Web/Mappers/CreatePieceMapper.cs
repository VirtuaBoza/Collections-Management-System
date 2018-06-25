using CoraCorpCM.Application.Pieces.Commands.CreatePiece;
using CoraCorpCM.Web.ViewModels.CollectionViewModels;

namespace CoraCorpCM.Web.Mappers
{
    public class CreatePieceMapper : ICreatePieceMapper
    {
        public CreatePieceModel Map(CreatePieceViewModel model, string userId, int museumId)
        {
            return new CreatePieceModel
            {
                AccessionNumber = model.AccessionNumber,
                AcquisitionCost = model.AcquisitionCost,
                AcquisitionDate = model.AcquisitionDate,
                AcquisitionId = model.AcquisitionId,
                AcquisitionTerms = model.AcquisitionTerms,
                ArtistAlsoKnownAs = model.ArtistAlsoKnownAs,
                ArtistBirthDate = model.ArtistBirthDate,
                ArtistCityOfOrigin = model.ArtistCityOfOrigin,
                ArtistCountryOfOriginId = model.ArtistCountryOfOriginId,
                ArtistDeathDate = model.ArtistDeathDate,
                ArtistName = model.ArtistName,
                ArtistId = model.ArtistId,
                ArtistStateOfOrigin = model.ArtistStateOfOrigin,
                CityOfOrigin = model.CityOfOrigin,
                CollectionId = model.CollectionId,
                CollectionName = model.CollectionName,
                CopyrightOwner = model.CopyrightOwner,
                CopyrightYear = model.CopyrightYear,
                CountryOfOriginId = model.CountryOfOriginId,
                CreationDay = model.CreationDay,
                CreationMonth = model.CreationMonth,
                CreationYear = model.CreationYear,
                CurrentLocationAddress1 = model.CurrentLocationAddress1,
                CurrentLocationAddress2 = model.CurrentLocationAddress2,
                CurrentLocationCity = model.CurrentLocationCity,
                CurrentLocationCountryId = model.CurrentLocationCountryId,
                CurrentLocationId = model.CurrentLocationId,
                CurrentLocationName = model.CurrentLocationName,
                CurrentLocationState = model.CurrentLocationState,
                CurrentLocationZipCode = model.CurrentLocationZipCode,
                Depth = model.Depth,
                EstimatedValue = model.EstimatedValue,
                FundingSourceId = model.FundingSourceId,
                FundingSourceName = model.FundingSourceName,
                GenreId = model.GenreId,
                GenreName = model.GenreName,
                Height = model.Height,
                InsuranceAmount = model.InsuranceAmount,
                InsuranceCarrier = model.InsuranceCarrier,
                InsuranceExpirationDate = model.InsuranceExpirationDate,
                InsurancePolicyNumber = model.InsurancePolicyNumber,
                IsArchived = model.IsArchived,
                IsFramed = model.IsFramed,
                LastModifiedByUserId = userId,
                MediumId = model.MediumId,
                MediumName = model.MediumName,
                MuseumId = museumId,
                PieceSourceId = model.PieceSourceId,
                PieceSourceName = model.PieceSourceName,
                PermanentLocationAddress1 = model.PermanentLocationAddress1,
                PermanentLocationAddress2 = model.PermanentLocationAddress2,
                PermanentLocationCity = model.PermanentLocationCity,
                PermanentLocationCountryId = model.PermanentLocationCountryId,
                PermanentLocationId = model.PermanentLocationId,
                PermanentLocationName = model.PermanentLocationName,
                PermanentLocationState = model.PermanentLocationState,
                PermanentLocationZipCode = model.PermanentLocationZipCode,
                StateOfOrigin = model.StateOfOrigin,
                Subject = model.Subject,
                SubgenreId = model.SubgenreId,
                SubgenreName = model.SubgenreName,
                SubjectMatterId = model.SubjectMatterId,
                SubjectMatterName = model.SubjectMatterName,
                Title = model.Title,
                UnitOfMeasureId = model.UnitOfMeasureId,
                Width = model.Width
            };
        }
    }
}
