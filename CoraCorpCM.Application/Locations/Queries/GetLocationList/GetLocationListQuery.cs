using CoraCorpCM.Application.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.Application.Locations.Queries.GetLocationList
{
    public class GetLocationListQuery : IGetLocationListQuery
    {
        private readonly ILocationRepository locationRepository;

        public GetLocationListQuery(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public List<LocationModel> Execute(int museumId)
        {
            var locations = locationRepository.GetAll()
                .Where(l => l.MuseumId == museumId)
                .Select(l => new LocationModel
                {
                    Id = l.Id,
                    Name = l.Name
                });

            return locations.ToList();
        }
    }
}
