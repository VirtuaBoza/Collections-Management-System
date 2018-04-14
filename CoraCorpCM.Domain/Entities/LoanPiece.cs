namespace CoraCorpCM.Domain.Entities
{
    public class LoanPiece
    {
        public int LoanId { get; set; }
        public virtual Loan Loan { get; set; }
        public int PieceId { get; set; }
        public virtual Piece Piece { get; set; }

        public int MuseumId { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
