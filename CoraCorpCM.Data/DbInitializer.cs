using CoraCorpCM.Domain;
using CoraCorpCM.Domain.Models;
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
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IMuseumRepository museumRepository)
        {
            context.Database.EnsureCreated();
            
            if (!context.Countries.Any())
            {
                //var filepath = Path.Combine(environment.ContentRootPath, "countries.json");
                var filepath = Path.Combine(Directory.GetParent(environment.ContentRootPath).ToString(), "CoraCorpCM.Data","countries.json");
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
                    var museum = new Museum
                    {
                        Name = "Example Museum",
                        ShortName = "ExMPL",
                        Address1 = "1 Street",
                        Address2 = "A Suite",
                        City = "Anytown",
                        State = "FL",
                        ZipCode = "12345",
                        Country = country
                    };
                    museum.Users.Add(fullControlUser);
                    museumRepository.AddMuseum(museum);

                    museumRepository.AddMedium(new Medium { Name = "Medium1", Museum = museum });
                    museumRepository.AddMedium(new Medium { Name = "Medium2", Museum = museum });
                    museumRepository.AddMedium(new Medium { Name = "Medium3", Museum = museum });

                    museumRepository.AddLocation(new Location { Name = "Location1", Address1 = "street1", Address2 = "suite1", City = "city1", State = "state1", ZipCode = "12345", Country = country, Museum = museum });
                    museumRepository.AddLocation(new Location { Name = "Location2", Address1 = "street2", Address2 = "suite2", City = "city2", State = "state2", ZipCode = "23456", Country = country, Museum = museum });
                    museumRepository.AddLocation(new Location { Name = "Location3", Address1 = "street3", Address2 = "suite3", City = "city3", State = "state3", ZipCode = "34567", Country = country, Museum = museum });

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

