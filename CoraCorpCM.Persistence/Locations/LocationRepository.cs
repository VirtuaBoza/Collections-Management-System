using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.Locations
{
    public class LocationRepository : Repository<Location,int>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
