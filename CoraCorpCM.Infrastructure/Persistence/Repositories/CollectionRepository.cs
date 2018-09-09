using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Infrastructure.Persistence.Contexts;

namespace CoraCorpCM.Infrastructure.Persistence.Repositories
{
    public class CollectionRepository : Repository<Collection, int>, ICollectionRepository
    {
        public CollectionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
