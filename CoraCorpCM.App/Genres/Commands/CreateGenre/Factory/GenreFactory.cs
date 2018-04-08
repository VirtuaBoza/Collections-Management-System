using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Genres.Commands.CreateGenre.Factory
{
    public class GenreFactory : IGenreFactory
    {
        public Genre Create(string name, int museumId)
        {
            var genre = new Genre();
            genre.Name = name;
            genre.MuseumId = museumId;

            return genre;
        }
    }
}
