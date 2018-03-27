using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.PieceSources
{
    public class PieceSourceRepository : Repository<PieceSource,int>, IPieceSourceRepository
    {
        public PieceSourceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
