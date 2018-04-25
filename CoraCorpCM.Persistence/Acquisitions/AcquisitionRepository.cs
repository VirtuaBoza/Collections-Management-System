using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Persistence.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Persistence.Acquisitions
{
    public class AcquisitionRepository : Repository<Acquisition,int>, IAcquisitionRepository
    {
        public AcquisitionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
