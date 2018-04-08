using CoraCorpCM.App.Membership;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace CoraCorpCM.App.Tests
{
    public class AppMockHelper
    {
        public static Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

    }
}
