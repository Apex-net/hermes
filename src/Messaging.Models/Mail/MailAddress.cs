namespace Apexnet.Messaging.Mail
{
    public class MailAddress
    {
        public MailAddress(string address, string displayName)
        {
            this.DisplayName = displayName;
            this.Address = address;
        }

        public string Address { get; private set; }

        public string DisplayName { get; private set; }
    }
}