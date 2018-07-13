using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.Acquisitions
{
    public class AcquisitionRepository : Repository<Acquisition,int>, IAcquisitionRepository
    {
        public AcquisitionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
