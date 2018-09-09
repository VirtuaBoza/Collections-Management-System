using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Infrastructure.Persistence.Contexts;

namespace CoraCorpCM.Infrastructure.Persistence.Repositories
{
    public class LocationRepository : Repository<Location,int>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
