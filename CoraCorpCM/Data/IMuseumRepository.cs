using CoraCorpCM.Models;

namespace CoraCorpCM.Data
{
    public interface IMuseumRepository
    {
        Museum CreateMuseum(string name, string shortname, 
            string address1, string address2, string city, string state, string zipCode, Country country);

        Museum GetMuseumByUser(ApplicationUser user);

        Country GetCountryByName(string name);
        Country GetFirstCountry();
    }
}