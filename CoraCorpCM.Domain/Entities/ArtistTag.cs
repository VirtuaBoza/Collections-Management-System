namespace CoraCorpCM.Domain.Entities
{
    public class ArtistTag : IMuseumEntity
    {
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
