using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Domain.Models
{
    public class Artist : INamedEntity, IMuseumEntity
    {
        public Artist()
        {
            ArtistGenres = new HashSet<ArtistGenre>();
            ArtistMedia = new HashSet<ArtistMedium>();
            ArtistSubgenres = new HashSet<ArtistSubgenre>();
            ArtistSubjectMatters = new HashSet<ArtistSubjectMatter>();
            ArtistTags = new HashSet<ArtistTag>();
            Pieces = new HashSet<Piece>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }
        public string AlsoKnownAs { get; set; }
        public string StateOfOrigin { get; set; }
        public string CityOfOrigin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Deathdate { get; set; }

        public virtual Country CountryOfOrigin { get; set; }

        public virtual ICollection<Piece> Pieces { get; set; }

        public virtual ICollection<ArtistGenre> ArtistGenres { get; set; }
        public virtual ICollection<ArtistMedium> ArtistMedia { get; set; }
        public virtual ICollection<ArtistSubgenre> ArtistSubgenres { get; set; }
        public virtual ICollection<ArtistSubjectMatter> ArtistSubjectMatters { get; set; }
        public virtual ICollection<ArtistTag> ArtistTags { get; set; }
    }
}
