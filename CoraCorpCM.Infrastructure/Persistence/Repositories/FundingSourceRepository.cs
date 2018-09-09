using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Infrastructure.Persistence.Contexts;

namespace CoraCorpCM.Infrastructure.Persistence.Repositories
{
    public class FundingSourceRepository : Repository<FundingSource, int>, IFundingSourceRepository
    {
        public FundingSourceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
