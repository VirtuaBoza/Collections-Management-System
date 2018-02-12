namespace CoraCorpCM.Domain
{
    public class PieceTag
    {
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
