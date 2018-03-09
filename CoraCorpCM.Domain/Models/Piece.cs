using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Domain.Models
{
    public class Piece
    {
        public Piece()
        {
            ExhibitionPieces = new HashSet<ExhibitionPiece>();
            Inspections = new HashSet<Inspection>();
            LoanPieces = new HashSet<LoanPiece>();
            PieceTags = new HashSet<PieceTag>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public int RecordNumber { get; set; }
        [Required]
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
        [Column(TypeName = "date")]
        public DateTime? InsuranceExpirationDate { get; set; }
        public decimal? InsuranceAmount { get; set; }
        public string InsuranceCarrier { get; set; }
        public bool IsFramed { get; set; }
        public bool IsArchived { get; set; }

        public Upload Photo { get; set; }
        public Artist Artist { get; set; }
        public Medium Medium { get; set; }
        public Genre Genre { get; set; }
        public Subgenre Subgenre { get; set; }
        public SubjectMatter SubjectMatter { get; set; }
        public Acquisition Acquisition { get; set; }
        public Location CurrentLocation { get; set; }
        public Location PermanentLocation { get; set; }
        public Collection Collection { get; set; }
        public DateTime LastModified { get; set; }
        public ApplicationUser LastModifiedBy { get; set; }

        public ICollection<Inspection> Inspections { get; set; }

        public ICollection<ExhibitionPiece> ExhibitionPieces { get; set; }
        public ICollection<LoanPiece> LoanPieces { get; set; }
        public ICollection<PieceTag> PieceTags { get; set; }
    }
}
