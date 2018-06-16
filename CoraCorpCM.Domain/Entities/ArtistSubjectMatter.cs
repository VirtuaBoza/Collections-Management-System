namespace CoraCorpCM.Domain.Entities
{
    public class ArtistSubjectMatter
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int SubjectMatterId { get; set; }
        public SubjectMatter SubjectMatter { get; set; }

        public int MuseumId { get; set; }
        public Museum Museum { get; set; }
    }
}
