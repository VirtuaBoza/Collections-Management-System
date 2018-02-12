using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain
{
    public class Condition
    {
        public int Id { get; set; }
        public Museum Museum { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
