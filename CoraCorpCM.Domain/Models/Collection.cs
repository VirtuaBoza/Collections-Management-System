using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class Collection : IEntity, IMuseumEntity
    {
        public Collection()
        {
            Pieces = new HashSet<Piece>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Piece> Pieces { get; set; }
    }
}
