using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.PieceSources
{
    public class PieceSourceRepository : Repository<PieceSource,int>, IPieceSourceRepository
    {
        public PieceSourceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
