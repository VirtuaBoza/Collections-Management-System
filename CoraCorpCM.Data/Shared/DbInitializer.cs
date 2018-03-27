using CoraCorpCM.App.Membership;
using CoraCorpCM.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Data.Shared
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext context;
        private readonly IHostingEnvironment environment;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbInitializer(
            ApplicationDbContext context,
            IHostingEnvironment environment,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.environment = environment;
            this.roleManager = roleManager;
        }

        public void Initialize()
        {
            context.Database.EnsureCreated();
            
            if (!context.Countries.Any())
            {
                var filepath = Path.Combine(Directory.GetParent(environment.ContentRootPath).ToString(), "CoraCorpCM.Data","countries.json");
                var json = File.ReadAllText(filepath);
                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                context.Countries.AddRange(countries);
                context.SaveChanges();
            }

            if (!context.UnitsOfMeasure.Any())
            {
                context.Add(new UnitOfMeasure { Abbreviation = "mm", Name = "millimeter" });
                context.Add(new UnitOfMeasure { Abbreviation = "cm", Name = "centimeter" });
                context.Add(new UnitOfMeasure { Abbreviation = "dm", Name = "decimeter" });
                context.Add(new UnitOfMeasure { Abbreviation = "m", Name = "meter" });
                context.Add(new UnitOfMeasure { Abbreviation = "in", Name = "inch" });
                context.Add(new UnitOfMeasure { Abbreviation = "ft", Name = "foot" });
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole(Role.Admin));
                roleManager.CreateAsync(new IdentityRole(Role.Contributor));
            }
        }
    }
}

