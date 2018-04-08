using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Locations.Commands.CreateLocation.Factory
{
    public class LocationFactory : ILocationFactory
    {
        public Location Create(string name, string address1, string address2, string city, string state, string zipcode, Country country, int museumId)
        {
            var location = new Location();
            location.Name = name;
            location.Address1 = address1;
            location.Address2 = address2;
            location.City = city;
            location.State = state;
            location.ZipCode = zipcode;
            location.Country = country;
            location.MuseumId = museumId;

            return location;
        }
    }
}
