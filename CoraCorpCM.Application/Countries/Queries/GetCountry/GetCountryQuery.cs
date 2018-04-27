using CoraCorpCM.Application.Interfaces.Persistence;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Countries.Queries.GetCountry
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
