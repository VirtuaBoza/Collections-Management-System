﻿using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Application.Models
{
    public class UnitOfMeasure : IEntity<int>
    {
        public int Id { get; set; }

        [Display(Name = "Units")]
        [Required]
        public string Abbreviation { get; set; }

        [Display(Name = "Unit of Measurement")]
        [Required]
        public string Name { get; set; }
    }
}
