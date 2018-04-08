using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Entities
{
    public class Medium : IEntity<int>, INamedEntity, IMuseumEntity
    {
        public Medium()
        {
            ArtistMedia = new HashSet<ArtistMedium>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ArtistMedium> ArtistMedia { get; set; }
    }
}
