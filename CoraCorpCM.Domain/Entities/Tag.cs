using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Entities
{
    public class Tag : IEntity<int>
    {
        public Tag()
        {
            ArtistTags = new HashSet<ArtistTag>();
            LocationTags = new HashSet<LocationTag>();
            PieceTags = new HashSet<PieceTag>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ArtistTag> ArtistTags { get; set; }
        public ICollection<LocationTag> LocationTags { get; set; }
        public ICollection<PieceTag> PieceTags { get; set; }
    }
}
