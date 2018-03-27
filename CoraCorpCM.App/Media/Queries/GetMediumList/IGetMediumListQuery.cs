using System.Collections.Generic;

namespace CoraCorpCM.App.Media.Queries.GetMediumList
{
    public interface IGetMediumListQuery
    {
        List<MediumModel> Execute(int museumId);
    }
}
