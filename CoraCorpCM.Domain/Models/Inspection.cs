using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Domain.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        public virtual Museum Museum { get; set; }

        [Required]
        public virtual Piece Piece { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public virtual Inspector Inspector { get; set; }
        public virtual Condition Condition { get; set; }
        public string Notes { get; set; }
    }
}
