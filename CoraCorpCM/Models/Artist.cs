using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoraCorpCM.Models
{
    public class Artist
    {
        public Artist()
        {
            ArtistGenres = new HashSet<ArtistGenre>();
            ArtistMedia = new HashSet<ArtistMedium>();
            ArtistSubgenres = new HashSet<ArtistSubgenre>();
            ArtistSubjectMatters = new HashSet<ArtistSubjectMatter>();
            ArtistTags = new HashSet<ArtistTag>();
            PieceArtists = new HashSet<PieceArtist>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string KnownAs { get; set; }

        public Origin Origin { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Deathdate { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; }

        public ICollection<ArtistMedium> ArtistMedia { get; set; }

        public ICollection<ArtistSubgenre> ArtistSubgenres { get; set; }

        public ICollection<ArtistSubjectMatter> ArtistSubjectMatters { get; set; }

        public ICollection<ArtistTag> ArtistTags { get; set; }

        public ICollection<PieceArtist> PieceArtists { get; set; }
    }
}
