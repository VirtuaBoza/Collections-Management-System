using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.Subgenres
{
    public class SubgenreRepository : Repository<Subgenre,int>, ISubgenreRepository
    {
        public SubgenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
