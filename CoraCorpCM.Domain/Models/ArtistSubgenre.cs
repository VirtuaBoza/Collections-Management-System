namespace CoraCorpCM.Domain.Models
{
    public class ArtistSubgenre
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int SubgenreId { get; set; }
        public Subgenre Subgenre { get; set; }

        public int MuseumId { get; set; }
        public Museum Museum { get; set; }
    }
}
