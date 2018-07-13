using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.Pieces
{
    public class PieceRepository : Repository<Piece,int>, IPieceRepository
    {
        public PieceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
