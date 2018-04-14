using Microsoft.AspNetCore.Mvc;

namespace CoraCorpCM.Web.Services.Account
{
    public interface ICallbackUrlCreator
    {
        string CreateEmailConfirmationLink(IUrlHelper urlHelper, string userId, string code, string scheme);
        string CreateResetPasswordCallbackLink(IUrlHelper urlHelper, string userId, string code, string scheme);
    }
}
