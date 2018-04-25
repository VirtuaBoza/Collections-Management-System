using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Pieces.Commands.RemovePiece
{
    public class RemovePieceCommand : IRemovePieceCommand
    {
        private readonly IPieceRepository pieceRepository;

        public RemovePieceCommand(IPieceRepository pieceRepository)
        {
            this.pieceRepository = pieceRepository;
        }

        public void Execute(Piece piece)
        {
            pieceRepository.Remove(piece);
        }
    }
}
