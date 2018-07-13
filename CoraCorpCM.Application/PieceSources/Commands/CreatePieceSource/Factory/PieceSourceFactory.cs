using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.PieceSources.Commands.CreatePieceSource.Factory
{
    public class PieceSourceFactory : IPieceSourceFactory
    {
        public PieceSource Create(string name, int museumId)
        {
            var pieceSource = new PieceSource();
            pieceSource.Name = name;
            pieceSource.MuseumId = museumId;

            return pieceSource;
        }
    }
}
