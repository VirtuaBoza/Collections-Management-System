using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain.Models
{
    public class SubjectMatter : IEntity, IMuseumEntity
    {
        public SubjectMatter()
        {
            Pieces = new HashSet<Piece>();

            ArtistSubjectMatters = new HashSet<ArtistSubjectMatter>();
        }

        public int Id { get; set; }

        public Museum Museum { get; set; }
        public int MuseumId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Piece> Pieces { get; set; }

        public ICollection<ArtistSubjectMatter> ArtistSubjectMatters { get; set; }
    }
}
