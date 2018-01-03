namespace CoraCorpCM.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public Museum Museum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
