using System.Threading.Tasks;
using CoraCorpCM.App.Membership;
using CoraCorpCM.Web.ViewModels.ManageViewModels;

namespace CoraCorpCM.Web.Services.Manage
{
    public interface ITwoFactorAuthenticationViewModelFactory
    {
        Task<TwoFactorAuthenticationViewModel> Create(ApplicationUser user);
    }
}