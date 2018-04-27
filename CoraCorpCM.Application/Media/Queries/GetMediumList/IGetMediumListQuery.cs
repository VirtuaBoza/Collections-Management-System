using System.Collections.Generic;

namespace CoraCorpCM.Application.Media.Queries.GetMediumList
{
    public interface IGetMediumListQuery
    {
        List<MediumModel> Execute(int museumId);
    }
}
