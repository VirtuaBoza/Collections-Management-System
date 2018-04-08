using CoraCorpCM.App.Countries.Queries.GetCountry;
using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Museums.Commands.RegisterMuseum.Factory
{
    public class MuseumFactory : IMuseumFactory
    {
        private readonly IGetCountryQuery getCountryQuery;

        public MuseumFactory(IGetCountryQuery getCountryQuery)
        {
            this.getCountryQuery = getCountryQuery;
        }

        public Museum Create(string name, string shortName, string address1, string address2, string city, string state, string zipCode, string countryId)
        {
            var museum = new Museum
            {
                Name = name,
                ShortName = shortName,
                Address1 = address1,
                Address2 = address2,
                City = city,
                State = state,
                ZipCode = zipCode
            };

            Country country = null;
            if (int.TryParse(countryId, out int id))
            {
                country = getCountryQuery.Execute(id);
            }

            return museum;
        }
    }
}
