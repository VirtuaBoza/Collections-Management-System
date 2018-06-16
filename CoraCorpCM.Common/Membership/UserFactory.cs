using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Common.Membership
{
    public class UserFactory : IUserFactory
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserFactory(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public ApplicationUser Create(int museumId, string email, string firstName, string lastName)
        {
            var user = new ApplicationUser
            {
                MuseumId = museumId,
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };

            return user;
        }
    }
}
