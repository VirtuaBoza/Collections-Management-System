namespace CoraCorpCM.Domain
{
    public class ArtistMedium
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int MediumId { get; set; }
        public Medium Medium { get; set; }
    }
}
