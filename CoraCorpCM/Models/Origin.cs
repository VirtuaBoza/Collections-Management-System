namespace CoraCorpCM.Models
{
    public class Origin
    {
        public int Id { get; set; }
        public Museum Museum { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
