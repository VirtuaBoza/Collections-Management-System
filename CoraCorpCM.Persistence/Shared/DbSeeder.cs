using CoraCorpCM.Common.Membership;
using CoraCorpCM.Domain.Entities;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoraCorpCM.Persistence.Shared
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public DbSeeder(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task Seed()
        {
            if (!context.Museums.Any())
            {
                var country = context.Countries.First();
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
                context.Add(museum);

                if (!context.Media.Any())
                {
                    context.Add(new Medium {Name = "Medium1", Museum = museum});
                    context.Add(new Medium {Name = "Medium2", Museum = museum});
                    context.Add(new Medium {Name = "Medium3", Museum = museum});
                }

                if (!context.Locations.Any())
                {
                    context.Add(new Location { Name = "Location1", Address1 = "street1", Address2 = "suite1", City = "city1", State = "state1", ZipCode = "12345", Country = country, Museum = museum });
                    context.Add(new Location { Name = "Location2", Address1 = "street2", Address2 = "suite2", City = "city2", State = "state2", ZipCode = "23456", Country = country, Museum = museum });
                    context.Add(new Location { Name = "Location3", Address1 = "street3", Address2 = "suite3", City = "city3", State = "state3", ZipCode = "34567", Country = country, Museum = museum });
                }

                var fullControlUser = new ApplicationUser
                {
                    UserName = "fullcontrol@email.com",
                    Email = "fullcontrol@email.com",
                    FirstName = "AndrewFC",
                    LastName = "Boza",
                    EmailConfirmed = true,
                    MuseumId = museum.Id
                };
                var fullControlUserResult =  await userManager.CreateAsync(fullControlUser, "password");
                if (fullControlUserResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(fullControlUser, Role.Admin);
                    await userManager.AddToRoleAsync(fullControlUser, Role.Contributor);
                }

                var adminUser = new ApplicationUser
                {
                    UserName = "admin@email.com",
                    Email = "admin@email.com",
                    FirstName = "AndrewAdmin",
                    LastName = "Boza",
                    EmailConfirmed = true,
                    MuseumId = museum.Id
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
                    MuseumId = museum.Id
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
                    MuseumId = museum.Id
                };
                await userManager.CreateAsync(readonlyUser, "password");
            }
        }
    }
}

