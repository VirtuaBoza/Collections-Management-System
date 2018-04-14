namespace CoraCorpCM.Domain.Entities
{
    public class ArtistMedium
    {
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public int MediumId { get; set; }
        public virtual Medium Medium { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
