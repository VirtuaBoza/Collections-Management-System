﻿using System.Collections.Generic;

namespace CoraCorpCM.Domain.Models
{
    public class PieceSource : INamedEntity, IMuseumEntity
    {
        public PieceSource()
        {
            Acquisitions = new HashSet<Acquisition>();
        }

        public int Id { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Acquisition> Acquisitions { get; set; }
    }
}
