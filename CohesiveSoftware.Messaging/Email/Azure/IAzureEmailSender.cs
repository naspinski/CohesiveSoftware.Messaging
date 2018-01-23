using System.Threading.Tasks;

namespace CohesiveSoftware.Messaging.Email.Azure
{
    public interface IAzureEmailSender
    {
        Task<ResponseMessage> SendAsync(EmailMessage message);
    }
}
