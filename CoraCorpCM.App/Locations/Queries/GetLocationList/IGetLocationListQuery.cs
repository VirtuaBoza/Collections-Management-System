using System.Collections.Generic;

namespace CoraCorpCM.App.Locations.Queries.GetLocationList
{
    public interface IGetLocationListQuery
    {
        List<LocationModel> Execute(int museumId);
    }
}
