using System.Collections.Generic;

namespace CoraCorpCM.App.Media.Queries
{
    public interface IGetMediumListQuery
    {
        List<MediumModel> Execute(int museumId);
    }
}
