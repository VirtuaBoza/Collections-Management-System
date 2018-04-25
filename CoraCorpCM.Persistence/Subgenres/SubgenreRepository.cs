using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Persistence.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Persistence.Subgenres
{
    public class SubgenreRepository : Repository<Subgenre,int>, ISubgenreRepository
    {
        public SubgenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
