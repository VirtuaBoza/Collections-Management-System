namespace CoraCorpCM.Models
{
    public class LoanPiece
    {
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
        public int PieceId { get; set; }
        public Piece Piece { get; set; }
    }
}
