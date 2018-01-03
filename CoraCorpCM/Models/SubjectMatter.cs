using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.Models
{
    public class SubjectMatter
    {
        public SubjectMatter()
        {
            ArtistSubjectMatters = new HashSet<ArtistSubjectMatter>();
            PieceSubjectMatters = new HashSet<PieceSubjectMatter>();
        }

        public int Id { get; set; }
        public Museum Museum { get; set; }
        public string Name { get; set; }
        public ICollection<ArtistSubjectMatter> ArtistSubjectMatters { get; set; }
        public ICollection<PieceSubjectMatter> PieceSubjectMatters { get; set; }
    }
}
