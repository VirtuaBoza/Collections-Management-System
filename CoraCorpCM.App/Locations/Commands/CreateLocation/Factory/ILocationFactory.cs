using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Locations.Commands.CreateLocation.Factory
{
    public interface ILocationFactory
    {
        Location Create(string name, string address1, string address2, string city, string state, string zipcode, Country country, int museumId);
    }
}
