using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Application.Models
{
    public class Country : IEntity<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(2)]
        [Required]
        public string Code { get; set; }
    }
}
