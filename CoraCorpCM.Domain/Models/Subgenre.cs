using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class Subgenre : INamedEntity, IMuseumEntity
    {
        public Subgenre()
        {
            ArtistSubgenres = new HashSet<ArtistSubgenre>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ArtistSubgenre> ArtistSubgenres { get; set; }
    }
}
