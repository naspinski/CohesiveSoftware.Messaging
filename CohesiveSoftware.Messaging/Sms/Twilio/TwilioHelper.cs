namespace CohesiveSoftware.Messaging.Sms.Twilio
{
    public class TwilioHelper
    {
        public string AuthToken;
        public string Sid;
        public string Phone;
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrWhiteSpace(AuthToken)
                  && !string.IsNullOrWhiteSpace(Sid)
                  && !string.IsNullOrWhiteSpace(Phone);
            }
        }

        public TwilioHelper(string authToken, string sid, string phone)
        {
            AuthToken = authToken;
            Sid = sid;
            Phone = phone;
        }
    }
}
