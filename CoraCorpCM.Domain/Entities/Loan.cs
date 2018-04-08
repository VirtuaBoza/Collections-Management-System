using System;
using System.Collections.Generic;

namespace CoraCorpCM.Domain.Entities
{
    public class Loan : IEntity<int>, IMuseumEntity
    {
        public Loan()
        {
            LoanPieces = new HashSet<LoanPiece>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        public virtual Location FromLocation { get; set; }
        public virtual Location ToLocation { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        public string Terms { get; set; }

        public virtual ICollection<LoanPiece> LoanPieces { get; set; }
    }
}
