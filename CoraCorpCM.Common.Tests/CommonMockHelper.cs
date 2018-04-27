using CoraCorpCM.Common.Membership;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace CoraCorpCM.Common.Tests
{
    public class CommonMockHelper
    {
        public static Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var mockUserStore = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
                mockUserStore.Object, null, null, null, null, null, null, null, null);
        }
    }
}
