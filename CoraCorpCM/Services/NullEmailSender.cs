using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoraCorpCM.Services
{
    public class NullEmailSender : IEmailSender
    {
        private readonly ILogger<NullEmailSender> logger;

        public NullEmailSender(ILogger<NullEmailSender> logger)
        {
            this.logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            logger.LogInformation($"Email: {email} Subject: {subject} Message: {message}");
            return Task.CompletedTask;
        }
    }
}
