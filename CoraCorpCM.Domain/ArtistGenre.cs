namespace CoraCorpCM.Domain
{
    public class ArtistGenre
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int MuseumId { get; set; }
        public Museum Museum { get; set; }
    }
}
