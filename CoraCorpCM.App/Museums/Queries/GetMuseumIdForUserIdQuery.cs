using CoraCorpCM.App.Membership;
using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.App.Museums.Queries
{
    public class GetMuseumIdForUserIdQuery : IGetMuseumIdForUserIdQuery
    {
        private readonly UserManager<ApplicationUser> userManager;

        public GetMuseumIdForUserIdQuery(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public int Execute(string userId)
        {
            var user = userManager.FindByIdAsync(userId).Result;
            return user.MuseumId;
        }
    }
}
