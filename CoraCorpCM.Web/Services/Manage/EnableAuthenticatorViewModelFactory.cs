using CoraCorpCM.Web.ViewModels.ManageViewModels;
using System.Text;
using System.Text.Encodings.Web;

namespace CoraCorpCM.Web.Services.Manage
{
    public class EnableAuthenticatorViewModelFactory : IEnableAuthenticatorViewModelFactory
    {
        private const string AuthenicatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

        private readonly UrlEncoder urlEncoder;

        public EnableAuthenticatorViewModelFactory(UrlEncoder urlEncoder)
        {
            this.urlEncoder = urlEncoder;
        }

        public EnableAuthenticatorViewModel Create(string unformattedKey, string email)
        {
            var viewModel = new EnableAuthenticatorViewModel();
            viewModel.SharedKey = FormatKey(unformattedKey);
            viewModel.AuthenticatorUri = GenerateQrCodeUri(email, unformattedKey);

            return viewModel;
        }

        private string FormatKey(string unformattedKey)
        {
            var result = new StringBuilder();
            int currentPosition = 0;
            while (currentPosition + 4 < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition, 4)).Append(" ");
                currentPosition += 4;
            }
            if (currentPosition < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition));
            }

            return result.ToString().ToLowerInvariant();
        }

        private string GenerateQrCodeUri(string email, string unformattedKey)
        {
            return string.Format(
                AuthenicatorUriFormat,
                urlEncoder.Encode("CoraCorpCM"),
                urlEncoder.Encode(email),
                unformattedKey);
        }
    }
}
