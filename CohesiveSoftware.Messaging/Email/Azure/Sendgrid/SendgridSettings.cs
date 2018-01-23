using System;
using System.Collections.Generic;
using System.Text;

namespace CohesiveSoftware.Messaging.Email.Azure.Sendgrid
{
    public class SendgridSettings
    {
        public string ApiKey { get; }

        public SendgridSettings(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Api Key must be set");

            this.ApiKey = apiKey;
        }
    }
}
