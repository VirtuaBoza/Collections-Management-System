using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoraCorpCM.Web.ExtensionWrappers
{
    public interface IAuthenticationHttpContextExtensionsWrapper
    {
        Task SignOutAsync(HttpContext context, string scheme);
    }
}