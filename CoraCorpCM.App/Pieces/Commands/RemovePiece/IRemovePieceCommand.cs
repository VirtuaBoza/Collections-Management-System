using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Pieces.Commands.RemovePiece
{
    public interface IRemovePieceCommand
    {
        void Execute(Piece piece);
    }
}
