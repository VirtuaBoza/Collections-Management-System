using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.Collections
{
    public class CollectionRepository : Repository<Collection, int>, ICollectionRepository
    {
        public CollectionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
