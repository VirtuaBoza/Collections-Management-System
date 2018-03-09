using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Domain
{
    public class Inspection
    {
        public int Id { get; set; }

        public Museum Museum { get; set; }

        [Required]
        public Piece Piece { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public Inspector Inspector { get; set; }
        public Condition Condition { get; set; }
        public string Notes { get; set; }
    }
}
