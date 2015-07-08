namespace Apexnet.Messaging.Mail
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MailMessage
    {
        public MailMessage()
        {
            this.To = new Collection<MailAddress>();
            this.Cc = new Collection<MailAddress>();
            this.Bcc = new Collection<MailAddress>();
        }

        public MailAddress From { get; set; }

        public IEnumerable<MailAddress> To { get; set; }

        public IEnumerable<MailAddress> Cc { get; set; }

        public IEnumerable<MailAddress> Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsBodyHtml { get; set; }
    }
}