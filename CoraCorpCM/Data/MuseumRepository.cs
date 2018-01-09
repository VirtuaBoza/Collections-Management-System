using CoraCorpCM.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoraCorpCM.Data
{
    public class MuseumRepository : IMuseumRepository
    {
        private readonly ApplicationDbContext context;

        public MuseumRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void CreateMuseum(string name, string shortname, string address1, string address2, string city, string state,
            Country country, ApplicationUser creator)
        {
            var museum = new Museum()
            {
                Name = name,
                ShortName = shortname,
                Address1 = address1,
                Address2 = address2,
                City = city,
                State = state,
                Country = country,
                ApplicationUsers = new List<ApplicationUser>
                {
                    creator
                }
            };
            context.Museums.Add(museum);
            context.SaveChanges();
        }

        public Museum GetMuseumByUser(ApplicationUser user)
        {
            context.Entry(user).Reference(u => u.Museum).Load();
            return user.Museum;
        }

        public Country GetCountryByName(string name)
        {
            return context.Countries.FirstOrDefault(c => c.Name == name);
        }
    }
}
