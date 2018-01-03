namespace CoraCorpCM.Models
{
    public class PieceSubjectMatter
    {
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
        public int SubjectMatterId { get; set; }
        public SubjectMatter SubjectMatter { get; set; }
    }
}
