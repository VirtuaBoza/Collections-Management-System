using CoraCorpCM.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CoraCorpCM.Web.Services.Shared
{
    public class CallbackUrlCreator : ICallbackUrlCreator
    {
        public string CreateEmailConfirmationLink(IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        public string CreateResetPasswordCallbackLink(IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
