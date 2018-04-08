using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Domain.Entities
{
    public class Acquisition : IEntity<int>, IMuseumEntity
    {
        public Acquisition()
        {
            Pieces = new HashSet<Piece>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        public decimal? Cost { get; set; }
        public string Terms { get; set; }

        public virtual FundingSource FundingSource { get; set; }
        public virtual PieceSource PieceSource { get; set; }

        public virtual ICollection<Piece> Pieces { get; set; }
    }
}
