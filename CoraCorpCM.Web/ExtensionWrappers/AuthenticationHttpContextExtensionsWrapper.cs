using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CoraCorpCM.Web.ExtensionWrappers
{
    public class AuthenticationHttpContextExtensionsWrapper : IAuthenticationHttpContextExtensionsWrapper
    {
        public async Task SignOutAsync(HttpContext context, string scheme)
        {
            await context.SignOutAsync(scheme);
        }
    }
}
