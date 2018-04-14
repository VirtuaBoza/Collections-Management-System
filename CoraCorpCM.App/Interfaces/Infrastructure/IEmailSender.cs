using System.Threading.Tasks;

namespace CoraCorpCM.App.Interfaces.Infrastructure
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailConfirmationAsync(string email, string link);
    }
}
