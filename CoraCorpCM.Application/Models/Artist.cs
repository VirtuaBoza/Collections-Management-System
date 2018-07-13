using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Application.Models
{
    public class Artist : IEntity<int>
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

        public Museum Museum { get; set; }
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

        public Country CountryOfOrigin { get; set; }

        public ICollection<Piece> Pieces { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; }
        public ICollection<ArtistMedium> ArtistMedia { get; set; }
        public ICollection<ArtistSubgenre> ArtistSubgenres { get; set; }
        public ICollection<ArtistSubjectMatter> ArtistSubjectMatters { get; set; }
        public ICollection<ArtistTag> ArtistTags { get; set; }
    }
}
