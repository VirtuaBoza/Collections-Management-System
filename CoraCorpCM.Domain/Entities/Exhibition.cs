using System;
using System.Collections.Generic;

namespace CoraCorpCM.Domain.Entities
{
    public class Exhibition : IEntity<int>
    {
        public Exhibition()
        {
            ExhibitionPieces = new HashSet<ExhibitionPiece>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        public string Name { get; set; }
        public string Curator { get; set; }
        public string Theme { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<ExhibitionPiece> ExhibitionPieces { get; set; }
    }
}
