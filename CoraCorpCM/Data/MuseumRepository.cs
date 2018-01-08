using CoraCorpCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoraCorpCM.Data
{
    public class MuseumRepository : IMuseumRepository
    {
        private readonly ApplicationDbContext context;

        public MuseumRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void CreateMuseum(string name, string shortname, Location location, ApplicationUser creator)
        {
            var museum = new Museum()
            {
                Name = name,
                ShortName = shortname,
                Location = location,
                ApplicationUsers = new List<ApplicationUser>
                {
                    creator
                }
            };
            context.Museums.Add(museum);
            context.SaveChanges();
        }

        public Location CreateLocation(string name, string address1, string address2, string city, string state, Country country)
        {
            var location = new Location()
            {
                Name = name,
                Address1 = address1,
                Address2 = address2,
                City = city,
                State = state,
                Country = country
            };
            return location;
        }

        public Country GetCountryByName(string name)
        {
            return context.Countries.FirstOrDefault(c => c.Name == name);
        }
    }
}
