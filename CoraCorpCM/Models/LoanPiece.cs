using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.Models
{
    public class LoanPiece
    {
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
    }
}
