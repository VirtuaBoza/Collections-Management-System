using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.Pieces.Commands.RemovePiece
{
    public interface IRemovePieceCommand
    {
        void Execute(Piece piece);
    }
}
