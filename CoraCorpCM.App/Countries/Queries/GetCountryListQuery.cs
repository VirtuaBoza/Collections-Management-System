using System.Collections.Generic;
using System.Linq;
using CoraCorpCM.App.Interfaces;
using CoraCorpCM.Domain.Models;

namespace CoraCorpCM.App.Countries.Queries
{
    public class GetCountryListQuery : IGetCountryListQuery
    {
        private readonly IMuseumRepository museumRepository;

        public GetCountryListQuery(IMuseumRepository museumRepository)
        {
            this.museumRepository = museumRepository;
        }

        public List<CountryModel> Execute()
        {
            var countries = museumRepository.GetEntities<Country>()
                .Select(c => new CountryModel
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return countries.ToList();
        }
    }
}
