using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Application.Models
{
    public class Genre : IEntity<int>
    {
        public Genre()
        {
            Pieces = new HashSet<Piece>();

            ArtistGenres = new HashSet<ArtistGenre>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Piece> Pieces { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}
