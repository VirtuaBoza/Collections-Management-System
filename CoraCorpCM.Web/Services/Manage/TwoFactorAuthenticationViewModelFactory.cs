using CoraCorpCM.App.Membership;
using CoraCorpCM.Web.ViewModels.ManageViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoraCorpCM.Web.Services.Manage
{
    public class TwoFactorAuthenticationViewModelFactory : ITwoFactorAuthenticationViewModelFactory
    {
        private readonly UserManager<ApplicationUser> userManager;

        public TwoFactorAuthenticationViewModelFactory(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<TwoFactorAuthenticationViewModel> Create(ApplicationUser user)
        {
            var viewModel = new TwoFactorAuthenticationViewModel();
            viewModel.HasAuthenticator = await userManager.GetAuthenticatorKeyAsync(user) != null;
            viewModel.Is2faEnabled = user.TwoFactorEnabled;
            viewModel.RecoveryCodesLeft = await userManager.CountRecoveryCodesAsync(user);

            return viewModel;
        }
    }
}
