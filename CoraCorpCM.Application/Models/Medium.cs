using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Application.Models
{
    public class Medium : IEntity<int>
    {
        public Medium()
        {
            ArtistMedia = new HashSet<ArtistMedium>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ArtistMedium> ArtistMedia { get; set; }
    }
}
