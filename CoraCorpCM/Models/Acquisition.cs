using System;
using System.Collections.Generic;

namespace CoraCorpCM.Models
{
    public class Acquisition
    {
        public Acquisition()
        {
            Pieces = new HashSet<Piece>();
        }

        public int Id { get; set; }
        public Museum Museum { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; }
        public decimal Cost { get; set; }
        public string Terms { get; set; }
        public FundingSource FundingSource { get; set; }
        public Upload PurchaseReceipt { get; set; }
        public PieceSource PieceSource { get; set; }
        public ICollection<Piece> Pieces { get; set; }
    }
}
