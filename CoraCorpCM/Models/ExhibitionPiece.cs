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
