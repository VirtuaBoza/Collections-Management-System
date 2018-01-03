using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.Models
{
    public class PieceTag
    {
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
