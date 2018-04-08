using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Genres.Commands.CreateGenre.Factory
{
    public interface IGenreFactory
    {
        Genre Create(string name, int museumId);
    }
}
