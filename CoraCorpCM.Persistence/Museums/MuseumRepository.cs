using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Domain.Entities;
using CoraCorpCM.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CoraCorpCM.Persistence.Museums
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
                .Single(m => m.Id == id);
        }
    }
}
