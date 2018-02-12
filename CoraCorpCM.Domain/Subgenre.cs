using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain
{
    public class Subgenre
    {
        public int Id { get; set; }
        public Museum Museum { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
