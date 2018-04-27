using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.Application.Locations.Commands.CreateLocation.Factory
{
    public interface ILocationFactory
    {
        Location Create(string name, string address1, string address2, string city, string state, string zipcode, Country country, int museumId);
    }
}
