namespace Apexnet.Messaging.Mail
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Newtonsoft.Json;

    public class MailMessage
    {
        public MailMessage(MailAddress from, MailAddress to, string subject, string body = "", bool isBodyHtml = false)
            : this(from, new Collection<MailAddress> { to }, subject, body, isBodyHtml)
        {
        }

        #region /// internal ///////////////////////////////////////////////////

        [JsonConstructor]
        private MailMessage(
            MailAddress from,
            ICollection<MailAddress> to,
            string subject,
            string body = "",
            bool isBodyHtml = false)
        {
            this.From = from;
            this.To = to;
            this.Cc = new Collection<MailAddress>();
            this.Bcc = new Collection<MailAddress>();
            this.Subject = subject;
            this.Body = body;
            this.IsBodyHtml = isBodyHtml;
        }

        #endregion

        public MailAddress From { get; private set; }

        public ICollection<MailAddress> To { get; private set; }

        public ICollection<MailAddress> Cc { get; private set; }

        public ICollection<MailAddress> Bcc { get; private set; }

        public string Subject { get; private set; }

        public string Body { get; private set; }

        public bool IsBodyHtml { get; private set; }
    }
}