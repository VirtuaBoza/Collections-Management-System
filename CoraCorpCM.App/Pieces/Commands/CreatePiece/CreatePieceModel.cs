using System;

namespace CoraCorpCM.App.Pieces.Commands.CreatePiece
{
    public class CreatePieceModel
    {
        public string Title { get; set; }
        public string AccessionNumber { get; set; }
        public int? CreationDay { get; set; }
        public int? CreationMonth { get; set; }
        public int? CreationYear { get; set; }
        public int? CountryOfOriginId { get; set; }
        public string StateOfOrigin { get; set; }
        public string CityOfOrigin { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Depth { get; set; }
        public int UnitOfMeasureId { get; set; }
        public decimal? EstimatedValue { get; set; }
        public string Subject { get; set; }
        public int? CopyrightYear { get; set; }
        public string CopyrightOwner { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTime? InsuranceExpirationDate { get; set; }
        public decimal? InsuranceAmount { get; set; }
        public string InsuranceCarrier { get; set; }
        public bool IsFramed { get; set; }
        public bool IsArchived { get; set; }
        public int? ArtistId { get; set; }
        public int? MediumId { get; set; }
        public int? GenreId { get; set; }
        public int? SubgenreId { get; set; }
        public int? SubjectMatterId { get; set; }
        public int? AcquisitionId { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? PermanentLocationId { get; set; }
        public int? CollectionId { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedByUserId { get; set; }

        public string MediumName { get; set; }

        public string GenreName { get; set; }

        public string SubgenreName { get; set; }

        public string SubjectMatterName { get; set; }

        public string PermanentLocationName { get; set; }
        public string PermanentLocationAddress1 { get; set; }
        public string PermanentLocationAddress2 { get; set; }
        public string PermanentLocationCity { get; set; }
        public string PermanentLocationState { get; set; }
        public string PermanentLocationZipCode { get; set; }
        public int? PermanentLocationCountryId { get; set; }

        public string CurrentLocationName { get; set; }
        public string CurrentLocationAddress1 { get; set; }
        public string CurrentLocationAddress2 { get; set; }
        public string CurrentLocationCity { get; set; }
        public string CurrentLocationState { get; set; }
        public string CurrentLocationZipCode { get; set; }
        public int? CurrentLocationCountryId { get; set; }

        public string ArtistName { get; set; }
        public string ArtistAlsoKnownAs { get; set; }
        public string ArtistStateOfOrigin { get; set; }
        public string ArtistCityOfOrigin { get; set; }
        public int? ArtistCountryOfOriginId { get; set; }
        public DateTime? ArtistBirthDate { get; set; }
        public DateTime? ArtistDeathDate { get; set; }

        public DateTime? AcquisitionDate { get; set; }
        public int? AcquisitionPieceSourceId { get; set; }
        public decimal? AcquisitionCost { get; set; }
        public int? AcquisitionFundingSourceId { get; set; }
        public string AcquisitionTerms { get; set; }

        public string PieceSourceName { get; set; }

        public string FundingSourceName { get; set; }

        public string CollectionName { get; set; }

        public int MuseumId { get; set; }
    }
}
