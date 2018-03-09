using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain
{
    public class Upload
    {
        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
