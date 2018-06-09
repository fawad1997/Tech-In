using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Tech_In.Services;

namespace Tech_In.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link,string body)
        {
            return emailSender.SendEmailAsync(email,
                "Confirm your email",
                body
                );
        }
    }
}
