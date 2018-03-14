﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class Collection : INamedEntity, IMuseumEntity
    {
        public Collection()
        {
            Pieces = new HashSet<Piece>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Piece> Pieces { get; set; }
    }
}
