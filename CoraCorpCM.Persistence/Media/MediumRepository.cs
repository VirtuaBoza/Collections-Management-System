using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.Media
{
    public class MediumRepository : Repository<Medium,int>, IMediumRepository
    {
        public MediumRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
