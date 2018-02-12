namespace CoraCorpCM.Domain
{
    public class ArtistSubgenre
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int SubgenreId { get; set; }
        public Subgenre Subgenre { get; set; }
    }
}
