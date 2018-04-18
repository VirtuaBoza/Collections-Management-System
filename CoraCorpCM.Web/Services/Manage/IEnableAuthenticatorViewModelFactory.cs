using System.Text.Encodings.Web;
using CoraCorpCM.Web.ViewModels.ManageViewModels;

namespace CoraCorpCM.Web.Services.Manage
{
    public interface IEnableAuthenticatorViewModelFactory
    {
        EnableAuthenticatorViewModel Create(string key, string email);
    }
}