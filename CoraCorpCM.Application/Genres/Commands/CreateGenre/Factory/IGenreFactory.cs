using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Genres.Commands.CreateGenre.Factory
{
    public interface IGenreFactory
    {
        Genre Create(string name, int museumId);
    }
}
