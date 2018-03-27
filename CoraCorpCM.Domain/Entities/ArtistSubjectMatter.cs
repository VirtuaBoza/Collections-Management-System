namespace CoraCorpCM.Domain.Entities
{
    public class ArtistSubjectMatter : IMuseumEntity
    {
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public int SubjectMatterId { get; set; }
        public virtual SubjectMatter SubjectMatter { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
