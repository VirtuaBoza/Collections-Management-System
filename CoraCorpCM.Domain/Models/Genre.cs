using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class Genre : INamedEntity, IMuseumEntity
    {
        public Genre()
        {
            Pieces = new HashSet<Piece>();

            ArtistGenres = new HashSet<ArtistGenre>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Piece> Pieces { get; set; }

        public virtual ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}
