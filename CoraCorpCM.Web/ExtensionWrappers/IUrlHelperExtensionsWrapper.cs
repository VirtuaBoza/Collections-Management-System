using Microsoft.AspNetCore.Mvc;

namespace CoraCorpCM.Web.ExtensionWrappers
{
    public interface IUrlHelperExtensionsWrapper
    {
        string Action(IUrlHelper helper, string action);
    }
}