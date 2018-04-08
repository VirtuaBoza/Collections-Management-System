using System.Collections.Generic;
using System.Linq;
using CoraCorpCM.App.Interfaces.Persistence;

namespace CoraCorpCM.App.Countries.Queries
{
    public class GetCountryListQuery : IGetCountryListQuery
    {
        private readonly ICountryRepository countryRepository;

        public GetCountryListQuery(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public List<CountryModel> Execute()
        {
            var countries = countryRepository.GetAll()
                .Select(c => new CountryModel
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return countries.ToList();
        }
    }
}
