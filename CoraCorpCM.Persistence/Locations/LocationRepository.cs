using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Persistence.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Persistence.Locations
{
    public class LocationRepository : Repository<Location,int>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
