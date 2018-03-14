using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class Upload
    {
        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
