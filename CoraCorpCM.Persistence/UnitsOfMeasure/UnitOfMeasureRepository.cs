using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Persistence.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Persistence.UnitsOfMeasure
{
    public class UnitOfMeasureRepository : ReadOnlyRepository<UnitOfMeasure,int>, IUnitOfMeasureRepository
    {
        public UnitOfMeasureRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
