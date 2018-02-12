using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain
{
    public class SubjectMatter
    {
        public SubjectMatter()
        {
            ArtistSubjectMatters = new HashSet<ArtistSubjectMatter>();
            Pieces = new HashSet<Piece>();
        }

        public int Id { get; set; }
        public Museum Museum { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ArtistSubjectMatter> ArtistSubjectMatters { get; set; }
        public ICollection<Piece> Pieces { get; set; }
    }
}
