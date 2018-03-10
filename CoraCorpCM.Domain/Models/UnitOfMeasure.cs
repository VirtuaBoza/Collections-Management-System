using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class UnitOfMeasure : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Units")]
        [Required]
        public string Abbreviation { get; set; }

        [Display(Name = "Unit of Measurement")]
        [Required]
        public string UnitOfMeasurement { get; set; }
    }
}
