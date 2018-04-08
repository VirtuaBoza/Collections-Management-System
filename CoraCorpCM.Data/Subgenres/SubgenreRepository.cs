using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.Subgenres
{
    public class SubgenreRepository : Repository<Subgenre,int>, ISubgenreRepository
    {
        public SubgenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
