namespace CoraCorpCM.Domain.Models
{
    public class ExhibitionPiece
    {
        public int ExhibitionId { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        public int PieceId { get; set; }
        public virtual Piece Piece { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
