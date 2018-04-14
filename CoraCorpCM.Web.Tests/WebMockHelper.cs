using CoraCorpCM.App.Membership;
using CoraCorpCM.App.Tests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace CoraCorpCM.Web.Tests
{
    public class WebMockHelper
    {
        public static Mock<SignInManager<ApplicationUser>> GetMockSignInManager()
        {
            var mockUserManager = AppMockHelper.GetMockUserManager();

            var mockContextAccessor = new Mock<IHttpContextAccessor>();

            var mockClaimsFactory = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();

            //var thing = new SignInManager<ApplicationUser>(,)

            return new Mock<SignInManager<ApplicationUser>>(
                mockUserManager.Object, mockContextAccessor.Object, mockClaimsFactory.Object, null, null, null);
        }
    }
}
