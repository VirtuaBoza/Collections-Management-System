using CoraCorpCM.Common.Membership;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace CoraCorpCM.Application.Tests
{
    public class AppMockHelper
    {
        public static Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var mockUserStore = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                mockUserStore.Object, null, null, null, null, null, null, null, null);
        }
    }
}
