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

        public ICollection<MailAddress> To { get; set; }

        public ICollection<MailAddress> Cc { get; set; }

        public ICollection<MailAddress> Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsBodyHtml { get; set; }
    }
}