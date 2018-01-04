using System.Collections.Generic;

namespace CoraCorpCM.Models
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
        public string Name { get; set; }
        public ICollection<ArtistSubjectMatter> ArtistSubjectMatters { get; set; }
        public ICollection<Piece> Pieces { get; set; }
    }
}
