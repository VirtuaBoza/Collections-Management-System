using System.Collections.Generic;

namespace CoraCorpCM.Application.Pieces.Queries
{
    public interface IGetPieceListQuery
    {
        List<PieceModel> Execute(int museumId);
    }
}
