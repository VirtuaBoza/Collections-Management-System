using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.UnitsOfMeasure
{
    public class UnitOfMeasureRepository : ReadOnlyRepository<UnitOfMeasure,int>, IUnitOfMeasureRepository
    {
        public UnitOfMeasureRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
