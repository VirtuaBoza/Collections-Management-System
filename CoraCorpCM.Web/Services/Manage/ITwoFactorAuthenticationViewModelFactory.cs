using System.Threading.Tasks;
using CoraCorpCM.Common.Membership;
using CoraCorpCM.Web.ViewModels.ManageViewModels;

namespace CoraCorpCM.Web.Services.Manage
{
    public interface ITwoFactorAuthenticationViewModelFactory
    {
        Task<TwoFactorAuthenticationViewModel> Create(ApplicationUser user);
    }
}