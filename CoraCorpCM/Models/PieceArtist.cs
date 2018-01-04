namespace CoraCorpCM.Models
{
    public class PieceArtist
    {
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
