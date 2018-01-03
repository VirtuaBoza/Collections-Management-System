using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.Models
{
    public class ExhibitionPiece
    {
        public int ExhibitionId { get; set; }
        public Exhibition Exhibition { get; set; }
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
    }
}
