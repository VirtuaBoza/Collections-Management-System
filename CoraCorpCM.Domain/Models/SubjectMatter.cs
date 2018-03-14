using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class SubjectMatter : INamedEntity, IMuseumEntity
    {
        public SubjectMatter()
        {
            Pieces = new HashSet<Piece>();

            ArtistSubjectMatters = new HashSet<ArtistSubjectMatter>();
        }

        public int Id { get; set; }

        public virtual Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Piece> Pieces { get; set; }

        public virtual ICollection<ArtistSubjectMatter> ArtistSubjectMatters { get; set; }
    }
}
