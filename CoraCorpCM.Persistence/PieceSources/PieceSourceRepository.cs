using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Persistence.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Persistence.PieceSources
{
    public class PieceSourceRepository : Repository<PieceSource,int>, IPieceSourceRepository
    {
        public PieceSourceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
