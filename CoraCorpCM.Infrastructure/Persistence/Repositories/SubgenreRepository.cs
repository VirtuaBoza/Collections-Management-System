using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Infrastructure.Persistence.Contexts;

namespace CoraCorpCM.Infrastructure.Persistence.Repositories
{
    public class SubgenreRepository : Repository<Subgenre,int>, ISubgenreRepository
    {
        public SubgenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
