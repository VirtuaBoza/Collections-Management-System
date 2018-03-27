using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Data.Shared;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Data.Genres
{
    public class GenreRepository : Repository<Genre,int>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
