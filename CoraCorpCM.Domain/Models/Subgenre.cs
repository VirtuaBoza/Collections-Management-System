using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class Subgenre
    {
        public Subgenre()
        {
            ArtistSubgenres = new HashSet<ArtistSubgenre>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ArtistSubgenre> ArtistSubgenres { get; set; }
    }
}
