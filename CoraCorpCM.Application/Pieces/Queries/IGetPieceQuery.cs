namespace CoraCorpCM.Application.Pieces.Queries
{
    public interface IGetPieceQuery
    {
        PieceModel Execute(int id);
    }
}
