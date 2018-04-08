using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Entities
{
    public class UnitOfMeasure : IEntity<int>, INamedEntity
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
