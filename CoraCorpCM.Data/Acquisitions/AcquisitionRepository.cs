using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.Acquisitions
{
    public class AcquisitionRepository : Repository<Acquisition,int>, IAcquisitionRepository
    {
        public AcquisitionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
