using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Persistence.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Persistence.Pieces
{
    public class PieceRepository : Repository<Piece,int>, IPieceRepository
    {
        public PieceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
