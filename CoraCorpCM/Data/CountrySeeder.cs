using CoraCorpCM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoraCorpCM.Data
{
    public class CountrySeeder
    {
        private readonly ApplicationDbContext context;
        private readonly IHostingEnvironment environment;
        private readonly ILogger<CountrySeeder> logger;

        public CountrySeeder(ApplicationDbContext context, IHostingEnvironment environment, ILogger<CountrySeeder> logger)
        {
            this.context = context;
            this.environment = environment;
            this.logger = logger;
        }

        public void Seed()
        {
            context.Database.EnsureCreated();
            
            if (!context.Countries.Any())
            {
                logger.LogInformation("I should be seeding countries.");

                var filepath = Path.Combine(environment.ContentRootPath,"Data/countries.json");
                var json = File.ReadAllText(filepath);
                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                context.Countries.AddRange(countries);
                context.SaveChanges();
            }
        }
    }
}
