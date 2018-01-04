using System;
using System.Collections.Generic;

namespace CoraCorpCM.Models
{
    public class Exhibition
    {
        public Exhibition()
        {
            Pieces = new HashSet<Piece>();
        }

        public int Id { get; set; }
        public Museum Museum { get; set; }
        public string Name { get; set; }
        public string Curator { get; set; }
        public string Theme { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Location Location { get; set; }
        public ICollection<Piece> Pieces { get; set; }
    }
}
