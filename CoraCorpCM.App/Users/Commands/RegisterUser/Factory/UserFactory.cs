using CoraCorpCM.Domain.Entities;
using CoraCorpCM.App.Membership;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.App.Users.Commands.RegisterUser.Factory
{
    public class UserFactory : IUserFactory
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserFactory(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public ApplicationUser Create(Museum museum, string email, string firstName, string lastName)
        {
            var user = new ApplicationUser
            {
                Museum = museum,
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };

            return user;
        }
    }
}
