using System.Collections.Generic;

namespace CoraCorpCM.Application.Locations.Queries.GetLocationList
{
    public interface IGetLocationListQuery
    {
        List<LocationModel> Execute(int museumId);
    }
}
