using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Application.Models;
using CoraCorpCM.Persistence.Shared;

namespace CoraCorpCM.Persistence.Countries
{
    public class CountryRepository : ReadOnlyRepository<Country,int>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
