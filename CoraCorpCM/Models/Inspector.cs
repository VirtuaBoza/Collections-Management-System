namespace CoraCorpCM.Models
{
    public class Inspector
    {
        public int Id { get; set; }
        public Museum Museum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string KnownAs { get; set; }
    }
}
