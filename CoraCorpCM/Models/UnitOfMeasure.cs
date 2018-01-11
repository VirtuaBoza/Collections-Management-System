using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Models
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }

        [Display(Name = "Units")]
        public string Abbreviation { get; set; }

        [Display(Name = "Unit of Measurement")]
        public string UnitOfMeasurement { get; set; }
    }
}
