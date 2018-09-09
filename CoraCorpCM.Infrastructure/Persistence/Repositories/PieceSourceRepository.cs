using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Infrastructure.Persistence.Contexts;

namespace CoraCorpCM.Infrastructure.Persistence.Repositories
{
    public class PieceSourceRepository : Repository<PieceSource,int>, IPieceSourceRepository
    {
        public PieceSourceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
