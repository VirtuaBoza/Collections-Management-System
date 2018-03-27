using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.Media
{
    public class MediumRepository : Repository<Medium,int>, IMediumRepository
    {
        public MediumRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
