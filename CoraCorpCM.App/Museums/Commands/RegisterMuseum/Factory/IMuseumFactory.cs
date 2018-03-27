using CoraCorpCM.Domain.Entities;

namespace CoraCorpCM.App.Museums.Commands.RegisterMuseum.Factory
{
    public interface IMuseumFactory
    {
        Museum Create(string name, string shortName, string address1, string address2, string city, string state, string zipCode, string countryId);
    }
}
