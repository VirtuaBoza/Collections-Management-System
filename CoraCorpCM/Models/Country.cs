using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength(2)]
        public string Genc2A { get; set; }
    }
}
