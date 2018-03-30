using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Domain.Entities
{
    public class Piece : IEntity<int>, IMuseumEntity
    {
        public Piece()
        {
            Inspections = new HashSet<Inspection>();
            ExhibitionPieces = new HashSet<ExhibitionPiece>();
            LoanPieces = new HashSet<LoanPiece>();
            PieceTags = new HashSet<PieceTag>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public int RecordNumber { get; set; }
        [Required]
        public string Title { get; set; }
        public string AccessionNumber { get; set; }
        public int? CreationDay { get; set; }
        public int? CreationMonth { get; set; }
        public int? CreationYear { get; set; }
        public virtual Country CountryOfOrigin { get; set; }
        public string StateOfOrigin { get; set; }
        public string CityOfOrigin { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Depth { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
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
        public DateTime LastModified { get; set; }

        public virtual Upload Photo { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Medium Medium { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Subgenre Subgenre { get; set; }
        public virtual SubjectMatter SubjectMatter { get; set; }
        public virtual Acquisition Acquisition { get; set; }
        public virtual Location CurrentLocation { get; set; }
        public virtual Location PermanentLocation { get; set; }
        public virtual Collection Collection { get; set; }

        /// <summary>  
        ///  The ID of the user who last modified the Piece  
        /// </summary> 
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }

        public virtual ICollection<ExhibitionPiece> ExhibitionPieces { get; set; }
        public virtual ICollection<LoanPiece> LoanPieces { get; set; }
        public virtual ICollection<PieceTag> PieceTags { get; set; }
    }
}
