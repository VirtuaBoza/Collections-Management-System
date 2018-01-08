using CoraCorpCM.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoraCorpCM.Data
{
    public static class CountrySeeder
    {
        public static void Seed(ApplicationDbContext context, IHostingEnvironment environment)
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
        }
    }
}
