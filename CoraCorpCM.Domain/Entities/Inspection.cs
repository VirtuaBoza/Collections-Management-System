using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Domain.Entities
{
    public class Inspection : IEntity<int>
    {
        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public Piece Piece { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public Inspector Inspector { get; set; }
        public Condition Condition { get; set; }
        public string Notes { get; set; }
    }
}
