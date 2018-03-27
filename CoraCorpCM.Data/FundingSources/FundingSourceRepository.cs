using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.FundingSources
{
    public class FundingSourceRepository : Repository<FundingSource,int>, IFundingSourceRepository
    {
        public FundingSourceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
