using System.Collections.Generic;

namespace CoraCorpCM.Application.PieceSources.Queries.GetPieceSourceList
{
    public interface IGetPieceSourceListQuery
    {
        List<PieceSourceModel> Execute(int museumId);
    }
}
