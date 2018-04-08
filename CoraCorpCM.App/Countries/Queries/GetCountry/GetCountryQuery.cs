using CoraCorpCM.App.Interfaces.Persistence;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Countries.Queries.GetCountry
{
    public class GetCountryQuery : IGetCountryQuery
    {
        private readonly ICountryRepository countryRepository;

        public GetCountryQuery(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public Country Execute(int id)
        {
            return countryRepository.Get(id);
        }
    }
}
