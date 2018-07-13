using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.Genres
{
    public class GenreRepository : Repository<Genre,int>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
