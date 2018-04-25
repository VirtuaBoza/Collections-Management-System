using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Persistence.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Persistence.Media
{
    public class MediumRepository : Repository<Medium,int>, IMediumRepository
    {
        public MediumRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
