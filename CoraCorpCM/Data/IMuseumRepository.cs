using CoraCorpCM.Models;

namespace CoraCorpCM.Data
{
    public interface IMuseumRepository
    {
        void CreateMuseum(string name, string shortname, Location location, ApplicationUser creator);

        Location CreateLocation(string name, string address1, string address2, string city, string state, Country country);

        Museum GetMuseumByUser(ApplicationUser user);

        Country GetCountryByName(string name);
    }
}