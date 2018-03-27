using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.UnitsOfMeasure
{
    public class UnitOfMeasureRepository : ReadOnlyRepository<UnitOfMeasure,int>, IUnitOfMeasureRepository
    {
        public UnitOfMeasureRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
