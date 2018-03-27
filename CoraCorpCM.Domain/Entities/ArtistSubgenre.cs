namespace CoraCorpCM.Domain.Entities
{
    public class ArtistSubgenre : IMuseumEntity
    {
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public int SubgenreId { get; set; }
        public virtual Subgenre Subgenre { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
