using CoraCorpCM.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(
            ApplicationDbContext context,
            IHostingEnvironment environment,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            
            if (!context.Countries.Any())
            {
                var filepath = Path.Combine(environment.ContentRootPath, "Data/countries.json");
                var json = File.ReadAllText(filepath);
                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                context.Countries.AddRange(countries);
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
                await roleManager.CreateAsync(new IdentityRole("Contributor"));
            }
        }
    }
}
