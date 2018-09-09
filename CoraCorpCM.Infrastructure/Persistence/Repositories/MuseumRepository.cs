using CoraCorpCM.Application.Interfaces.Persistence;
using System.Linq;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CoraCorpCM.Infrastructure.Persistence.Repositories
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
