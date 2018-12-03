using CohesiveSoftware.Messaging.Email.Azure;
using CohesiveSoftware.Messaging.Email.Azure.Sendgrid;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CohesiveSoftware.Messaging.Email
{
    public static class EmailSender
    {
        public static Task Send(string apiKey, string subject, string message, string toEmail, string fromEmail, IEnumerable<IFormFile> attachments = null)
        {
            var email = EmailMessageBuilder.Init()
                            .AddSubject(subject)
                            .AddFrom(fromEmail)
                            .AddBody(message)
                            .AddTo(toEmail);

            if (attachments != null)
            {
                foreach (var file in attachments)
                    email.AddAttachment(file);
            }

            var emailMessage = email.Build();

            IAzureEmailSender sender = new SendgridEmailSender(new SendgridSettings(apiKey));
            return sender.SendAsync(emailMessage);
        }
    }
}
