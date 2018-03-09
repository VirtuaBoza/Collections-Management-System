namespace CoraCorpCM.Domain.Models
{
    public class ArtistTag
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int MuseumId { get; set; }
        public Museum Museum { get; set; }
    }
}
