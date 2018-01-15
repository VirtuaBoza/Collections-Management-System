using CoraCorpCM.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoraCorpCM.Identity;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(
            ApplicationDbContext context,
            IHostingEnvironment environment,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IMuseumRepository museumRepository)
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

            if (!context.UnitsOfMeasure.Any())
            {
                context.Add(new UnitOfMeasure { Abbreviation = "mm", UnitOfMeasurement = "millimeter" });
                context.Add(new UnitOfMeasure { Abbreviation = "cm", UnitOfMeasurement = "centimeter" });
                context.Add(new UnitOfMeasure { Abbreviation = "dm", UnitOfMeasurement = "decimeter" });
                context.Add(new UnitOfMeasure { Abbreviation = "m", UnitOfMeasurement = "meter" });
                context.Add(new UnitOfMeasure { Abbreviation = "in", UnitOfMeasurement = "inch" });
                context.Add(new UnitOfMeasure { Abbreviation = "ft", UnitOfMeasurement = "foot" });
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Role.Admin));
                await roleManager.CreateAsync(new IdentityRole(Role.Contributor));
            }

            if (environment.IsDevelopment())
            {

                if (!context.Users.Any() && !context.Museums.Any())
                {
                    var fullControlUser = new ApplicationUser
                    {
                        UserName = "fullcontrol@email.com",
                        Email = "fullcontrol@email.com",
                        FirstName = "AndrewFC",
                        LastName = "Boza",
                        EmailConfirmed = true
                    };
                    var fullControlUserResult = await userManager.CreateAsync(fullControlUser, "password");
                    if (fullControlUserResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(fullControlUser, Role.Admin);
                        await userManager.AddToRoleAsync(fullControlUser, Role.Contributor);
                    }

                    var country = museumRepository.GetFirstCountry();
                    var museum = museumRepository.CreateMuseum("Example Museum", "ExMPL",
                        "1 Street", "A Suite", "Anytown", "FL", "12345", country,
                        fullControlUser);

                    museumRepository.CreateMedium("Medium1", museum);
                    museumRepository.CreateMedium("Medium2", museum);
                    museumRepository.CreateMedium("Medium3", museum);

                    museumRepository.CreateLocation("Location1", "street1", "suite1", "city1", "state1", "12345", country, museum);
                    museumRepository.CreateLocation("Location2", "street2", "suite2", "city2", "state2", "23456", country, museum);
                    museumRepository.CreateLocation("Location3", "street3", "suite3", "city3", "state3", "34567", country, museum);

                    var adminUser = new ApplicationUser
                    {
                        UserName = "admin@email.com",
                        Email = "admin@email.com",
                        FirstName = "AndrewAdmin",
                        LastName = "Boza",
                        EmailConfirmed = true,
                        Museum = museum
                    };
                    var adminUserResult = await userManager.CreateAsync(adminUser, "password");
                    if (adminUserResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, Role.Admin);
                    }

                    var contributorUser = new ApplicationUser
                    {
                        UserName = "contributor@email.com",
                        Email = "contributor@email.com",
                        FirstName = "AndrewCon",
                        LastName = "Boza",
                        EmailConfirmed = true,
                        Museum = museum
                    };
                    var contributorUserResult = await userManager.CreateAsync(contributorUser, "password");
                    if (contributorUserResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(contributorUser, Role.Contributor);
                    }

                    var readonlyUser = new ApplicationUser
                    {
                        UserName = "readonly@email.com",
                        Email = "readonly@email.com",
                        FirstName = "AndrewRO",
                        LastName = "Boza",
                        EmailConfirmed = true,
                        Museum = museum
                    };
                    await userManager.CreateAsync(readonlyUser, "password");
                }
            }
        }
    }
}

