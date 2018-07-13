using CoraCorpCM.Application.Models;

namespace CoraCorpCM.Application.Museums.Commands.CreateMuseum.Factory
{
    public interface IMuseumFactory
    {
        Museum Create(string name, string shortName, string address1, string address2, string city, string state, string zipCode, string countryId);
    }
}
