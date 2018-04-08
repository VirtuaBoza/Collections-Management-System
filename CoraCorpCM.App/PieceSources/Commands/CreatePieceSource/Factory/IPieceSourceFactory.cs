using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.PieceSources.Commands.CreatePieceSource.Factory
{
    public interface IPieceSourceFactory
    {
        PieceSource Create(string name, int museumId);
    }
}
