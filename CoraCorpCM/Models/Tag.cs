using System.Collections.Generic;

namespace CoraCorpCM.Models
{
    public class Tag
    {
        public Tag()
        {
            ArtistTags = new HashSet<ArtistTag>();
            LocationTags = new HashSet<LocationTag>();
            PieceTags = new HashSet<PieceTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ArtistTag> ArtistTags { get; set; }
        public ICollection<LocationTag> LocationTags { get; set; }
        public ICollection<PieceTag> PieceTags { get; set; }
    }
}
