using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.PieceSources.Commands.CreatePieceSource.Factory
{
    public interface IPieceSourceFactory
    {
        PieceSource Create(string name, int museumId);
    }
}
