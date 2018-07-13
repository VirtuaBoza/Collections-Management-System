using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.Genres.Commands.CreateGenre.Factory
{
    public interface IGenreFactory
    {
        Genre Create(string name, int museumId);
    }
}
