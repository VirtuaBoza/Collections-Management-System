using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Entities
{
    public class Upload : IEntity<int>, IMuseumEntity, INamedEntity
    {
        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
