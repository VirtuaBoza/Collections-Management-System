using System.Collections.Generic;

namespace CoraCorpCM.Application.Subgenres.Queries.GetSubgenreList
{
    public interface IGetSubgenreListQuery
    {
        List<SubgenreModel> Execute(int museumId);
    }
}
