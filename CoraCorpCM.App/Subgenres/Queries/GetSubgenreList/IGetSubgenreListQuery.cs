using System.Collections.Generic;

namespace CoraCorpCM.App.Subgenres.Queries.GetSubgenreList
{
    public interface IGetSubgenreListQuery
    {
        List<SubgenreModel> Execute(int museumId);
    }
}
