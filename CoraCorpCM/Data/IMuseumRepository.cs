using CoraCorpCM.Models;

namespace CoraCorpCM.Data
{
    public interface IMuseumRepository
    {
        void CreateMuseum(string name, string shortname, 
            string address1, string address2, string city, string state, Country country, 
            ApplicationUser creator);

        Museum GetMuseumByUser(ApplicationUser user);

        Country GetCountryByName(string name);
    }
}