using CohesiveSoftware.Messaging.Email.Azure;
using CohesiveSoftware.Messaging.Email.Azure.Sendgrid;
using System.Threading.Tasks;

namespace CohesiveSoftware.Messaging.Email
{
    public class EmailSender
    {
        public static Task Send(string apiKey, string subject, string message, string toEmail, string fromEmail)
        {
            var email = EmailMessageBuilder.Init()
                            .AddSubject(subject)
                            .AddFrom(fromEmail)
                            .AddBody(message)
                            .AddTo(toEmail)
                            .Build();

            IAzureEmailSender sender = new SendgridEmailSender(new SendgridSettings(apiKey));
            return sender.SendAsync(email);
        }
    }
}
