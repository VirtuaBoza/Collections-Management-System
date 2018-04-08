using CoraCorpCM.App.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.App.Genres.Queries.GetGenreList
{
    public class GetGenreListQuery : IGetGenreListQuery
    {
        private readonly IGenreRepository genreRepository;

        public GetGenreListQuery(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public List<GenreModel> Execute(int museumId)
        {
            var genres = genreRepository.GetAll()
                .Where(g => g.MuseumId == museumId)
                .Select(g => new GenreModel
                {
                    Id = g.Id,
                    Name = g.Name
                });

            return genres.ToList();
        }
    }
}
