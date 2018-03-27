using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.Pieces
{
    public class PieceRepository : Repository<Piece,int>, IPieceRepository
    {
        public PieceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
