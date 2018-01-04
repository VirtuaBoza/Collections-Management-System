using System;

namespace CoraCorpCM.Models
{
    public class Inspection
    {
        public int Id { get; set; }
        public Museum Museum { get; set; }
        public Piece Piece { get; set; }
        public DateTime Date { get; set; }
        public Inspector Inspector { get; set; }
        public Condition Condition { get; set; }
        public string Notes { get; set; }
    }
}
