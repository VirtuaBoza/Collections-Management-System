using Microsoft.AspNetCore.Mvc;

namespace CoraCorpCM.Web.ExtensionWrappers
{
    public class UrlHelperExtensionsWrapper : IUrlHelperExtensionsWrapper
    {
        public string Action(IUrlHelper helper, string action)
        {
            return helper.Action(action);
        }
    }
}
