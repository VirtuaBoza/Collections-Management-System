namespace CoraCorpCM.Domain.Entities
{
    public class ExhibitionPiece : IMuseumEntity
    {
        public int ExhibitionId { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        public int PieceId { get; set; }
        public virtual Piece Piece { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
