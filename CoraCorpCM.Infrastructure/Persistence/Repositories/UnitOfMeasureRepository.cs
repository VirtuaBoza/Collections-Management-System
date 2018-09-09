using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Infrastructure.Persistence.Contexts;

namespace CoraCorpCM.Infrastructure.Persistence.Repositories
{
    public class UnitOfMeasureRepository : ReadOnlyRepository<UnitOfMeasure,int>, IUnitOfMeasureRepository
    {
        public UnitOfMeasureRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
