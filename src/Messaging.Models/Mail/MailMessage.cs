namespace Apexnet.Messaging.Mail
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MailMessage
    {
        public MailMessage(MailAddress from, MailAddress to, string subject, string body = "", bool isBodyHtml = false)
            : this(from, new List<MailAddress> { to }, subject, body, isBodyHtml)
        {
        }

        #region /// internal ///////////////////////////////////////////////////

        [JsonConstructor]
        private MailMessage(
            MailAddress from,
            List<MailAddress> to,
            string subject,
            string body = "",
            bool isBodyHtml = false)
        {
            this.From = from;
            this.To = to;
            this.Cc = new List<MailAddress>();
            this.Bcc = new List<MailAddress>();
            this.Subject = subject;
            this.Body = body;
            this.IsBodyHtml = isBodyHtml;
            this.Attachments = new List<Attachment>();
        }

        #endregion

        public MailAddress From { get; private set; }

        public List<MailAddress> To { get; private set; }

        public List<MailAddress> Cc { get; private set; }

        public List<MailAddress> Bcc { get; private set; }

        public string Subject { get; private set; }

        public string Body { get; private set; }

        public bool IsBodyHtml { get; private set; }

        public List<Attachment> Attachments { get; private set; }
    }
}
