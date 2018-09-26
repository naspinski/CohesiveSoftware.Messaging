using CohesiveSoftware.Messaging.Email;
using System.Threading.Tasks;
using Xunit;

namespace CohesiveSoftware.Messaging.Tests
{
    public class EmailTests
    {
        [Fact]
        public void BasicSend()
        {
            BasicSendAsync().Wait();
        }

        private async Task BasicSendAsync()
        { 
            await EmailSender.Send(Keys.SendgridApiKey, 
                "CohesiveSoftware.Messaging.Tests.EmailTests.BasicSend", 
                "test message", 
                Keys.ToEmail, 
                Keys.FromEmail);
            Assert.True(true);
        }
    }
}
