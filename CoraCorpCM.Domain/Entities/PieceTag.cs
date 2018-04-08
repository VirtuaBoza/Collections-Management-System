namespace CoraCorpCM.Domain.Entities
{
    public class PieceTag : IMuseumEntity
    {
        public int PieceId { get; set; }
        public virtual Piece Piece { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
