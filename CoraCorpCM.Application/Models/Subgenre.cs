using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Application.Models
{
    public class Subgenre : IEntity<int>
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
