using System;
using System.Collections.Generic;
using System.Text;

namespace CohesiveSoftware.Messaging.Email
{
    public class ResponseMessage
    {
        public ResponseMessage(string statusCode)
        {
            this.StatusCode = statusCode;
        }

        public string StatusCode { get; }
    }
}
