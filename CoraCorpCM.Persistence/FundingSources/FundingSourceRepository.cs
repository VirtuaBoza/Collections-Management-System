using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.FundingSources
{
    public class FundingSourceRepository : Repository<FundingSource, int>, IFundingSourceRepository
    {
        public FundingSourceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
