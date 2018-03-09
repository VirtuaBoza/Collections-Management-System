using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Domain
{
    public class Acquisition
    {
        public Acquisition()
        {
            Pieces = new HashSet<Piece>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public decimal? Cost { get; set; }
        public string Terms { get; set; }

        public FundingSource FundingSource { get; set; }
        public Upload PurchaseReceipt { get; set; }
        public PieceSource PieceSource { get; set; }

        public ICollection<Piece> Pieces { get; set; }
    }
}
