using System.Collections.Generic;

namespace CoraCorpCM.App.PieceSources.Queries.GetPieceSourceList
{
    public interface IGetPieceSourceListQuery
    {
        List<PieceSourceModel> Execute(int museumId);
    }
}
