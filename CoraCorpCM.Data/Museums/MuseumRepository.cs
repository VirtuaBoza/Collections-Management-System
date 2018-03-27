using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Domain.Entities;
using CoraCorpCM.Data.Shared;

namespace CoraCorpCM.Data.Museums
{
    public class MuseumRepository : Repository<Museum,int>, IMuseumRepository
    {
        public MuseumRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
