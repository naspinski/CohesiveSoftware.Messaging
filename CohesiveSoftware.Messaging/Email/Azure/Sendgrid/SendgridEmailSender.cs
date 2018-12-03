using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CohesiveSoftware.Messaging.Email.Azure.Sendgrid
{
    public class SendgridEmailSender : IAzureEmailSender
    {
        private readonly SendgridSettings settings;

        public SendgridEmailSender(SendgridSettings settings)
        {
            this.settings = settings;
        }

        public async Task<ResponseMessage> SendAsync(EmailMessage message)
        {
            // Message
            var msg = new SendGridMessage();
            msg.Subject = message.Subject;
            msg.From = new EmailAddress(message.From);
            msg.PlainTextContent = message.Body;
            msg.AddTos(message.To.Select(s => new EmailAddress(s)).ToList());

            if (message.CC.Count > 0)
                msg.AddCcs(message.CC.Select(s => new EmailAddress(s)).ToList());

            if (message.BCC.Count > 0)
                msg.AddBccs(message.BCC.Select(s => new EmailAddress(s)).ToList());

            if (message.Attachments != null && message.Attachments.Any())
            {
                foreach (var attachment in message.Attachments.Where(x => x != null && x.Length > 0))
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        msg.AddAttachment(new Attachment
                        {
                            Filename = attachment.FileName,
                            Content = Convert.ToBase64String(fileBytes)
                        });
                    }
                }
            }

            // Send
            var client = new SendGridClient(this.settings.ApiKey);
            var response = await client.SendEmailAsync(msg);

            // Return
            return new ResponseMessage(response.StatusCode.ToString());
        }
    }
}
