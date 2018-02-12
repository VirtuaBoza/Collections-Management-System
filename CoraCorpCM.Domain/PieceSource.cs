namespace CoraCorpCM.Domain
{
    public class PieceSource
    {
        public int Id { get; set; }
        public int MuseumId { get; set; }
        public Museum Museum { get; set; }
        public string Name { get; set; }
    }
}
