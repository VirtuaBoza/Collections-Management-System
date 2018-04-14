namespace CoraCorpCM.Domain.Entities
{
    public class LocationTag
    {
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
