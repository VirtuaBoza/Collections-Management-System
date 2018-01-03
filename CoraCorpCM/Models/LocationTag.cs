namespace CoraCorpCM.Models
{
    public class LocationTag
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
