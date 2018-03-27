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
        public string CountryOfOriginId { get; set; }
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

        public int MuseumId { get; set; }
    }
}
