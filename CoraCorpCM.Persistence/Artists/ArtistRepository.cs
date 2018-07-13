using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.Artists
{
    public class ArtistRepository : Repository<Artist,int>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
