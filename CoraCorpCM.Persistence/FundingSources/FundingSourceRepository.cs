using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Persistence.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Persistence.FundingSources
{
    public class FundingSourceRepository : Repository<FundingSource,int>, IFundingSourceRepository
    {
        public FundingSourceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
