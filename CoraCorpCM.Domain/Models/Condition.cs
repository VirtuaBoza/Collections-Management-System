﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class Condition
    {
        public Condition()
        {
            Inspections = new HashSet<Inspection>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
