using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tech_In.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, IConfiguration config)
        {
            Options = optionsAccessor.Value;
            this.configuration = config;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            apiKey = configuration.GetConnectionString("SendGridKey");
            var client = new SendGridClient(apiKey);
            //var client = new SendGridClient();
            var from = new EmailAddress("hassanali5062@gmail.com", "Tech In");
            var to = new EmailAddress(email);
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            return client.SendEmailAsync(msg);

        }
    }
}
