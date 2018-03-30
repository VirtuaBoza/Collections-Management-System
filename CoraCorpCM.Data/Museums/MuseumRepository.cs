using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Domain.Entities;
using CoraCorpCM.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoraCorpCM.Data.Museums
{
    public class MuseumRepository : Repository<Museum,int>, IMuseumRepository
    {
        private readonly ApplicationDbContext context;

        public MuseumRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override Museum Get(int id)
        {
            return context.Museums
                .Include(m => m.Country)
                .Include(m => m.Logo)
                .Single(m => m.Id == id);
        }
    }
}
