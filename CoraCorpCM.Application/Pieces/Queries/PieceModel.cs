using CoraCorpCM.Common.Membership;
using CoraCorpCM.Domain.Entities;
using System;

namespace CoraCorpCM.Application.Pieces.Queries
{
    public class PieceModel
    {
        public int Id { get; set; }
        public int RecordNumber { get; set; }
        public string Title { get; set; }
        public string AccessionNumber { get; set; }
        public int? CreationDay { get; set; }
        public int? CreationMonth { get; set; }
        public int? CreationYear { get; set; }
        public Country CountryOfOrigin { get; set; }
        public string StateOfOrigin { get; set; }
        public string CityOfOrigin { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Depth { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
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
        public DateTime LastModified { get; set; }
        public Artist Artist { get; set; }
        public Medium Medium { get; set; }
        public Genre Genre { get; set; }
        public Subgenre Subgenre { get; set; }
        public SubjectMatter SubjectMatter { get; set; }
        public Acquisition Acquisition { get; set; }
        public Location CurrentLocation { get; set; }
        public Location PermanentLocation { get; set; }
        public Collection Collection { get; set; }
        public ApplicationUser LastModifiedBy { get; set; }
    }
}
