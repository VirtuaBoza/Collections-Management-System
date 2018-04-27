using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using CoraCorpCM.Application.Interfaces.Infrastructure;

namespace CoraCorpCM.Infrastructure.Email
{
    /// <summary>
    /// This class is used by the application to send email for account confirmation and password reset.
    /// </summary>
    public class SendGridEmailSender : IEmailSender
    {
        public SendGridEmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            await ExecuteAsync(Options.SendGridKey, subject, message, email);
        }

        public async Task SendEmailConfirmationAsync(string email, string link)
        {
            await SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{link}'>link</a>");
        }

        public async Task ExecuteAsync(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress("noreply@coracorpcm.com", "CoraCorpCM"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            await client.SendEmailAsync(msg);
        }

    }
}
