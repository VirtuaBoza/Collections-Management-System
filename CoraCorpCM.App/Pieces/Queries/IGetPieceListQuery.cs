using System.Collections.Generic;

namespace CoraCorpCM.App.Pieces.Queries
{
    public interface IGetPieceListQuery
    {
        List<PieceModel> Execute(int museumId);
    }
}
