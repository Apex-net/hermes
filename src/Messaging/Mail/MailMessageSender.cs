namespace Apexnet.Messaging.Mail
{
    using System;
    using System.IO;
    using System.Net.Mail;

    using Apexnet.Messaging.Configuration;

    using Common.Utils;

    using MimeKit;

    public class MailMessageSender : IDisposable
    {
        private readonly SmtpClient smtpClient;

        public MailMessageSender()
            : this(null)
        {
        }

        private MailMessageSender(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient ?? new SmtpClient();
        }        

        public void Send(MailMessage message)
        {
            var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress(message.From.DisplayName, message.From.Address));

            message.To.Each((x, i) => mailMessage.To.Add(new MailboxAddress(x.DisplayName, x.Address)));
            message.Cc.Each((x, i) => mailMessage.Cc.Add(new MailboxAddress(x.DisplayName, x.Address)));
            message.Bcc.Each((x, i) => mailMessage.Bcc.Add(new MailboxAddress(x.DisplayName, x.Address)));

            mailMessage.Subject = message.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = message.Body;
            builder.TextBody = message.Body;

            foreach (var attachment in message.Attachments)
            {
                var stream = new MemoryStream(Convert.FromBase64String(attachment.Content));
                builder.Attachments.Add(attachment.FileName, stream);
            }

            mailMessage.Body = builder.ToMessageBody();

            var client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect(
                ApexnetMailSettingsReference.Instance.Smtp, 
                ApexnetMailSettingsReference.Instance.SmtpPort, 
                ApexnetMailSettingsReference.Instance.SmtpSsl);

            if (!string.IsNullOrWhiteSpace(ApexnetMailSettingsReference.Instance.SmtpUsername) &&
                !string.IsNullOrWhiteSpace(ApexnetMailSettingsReference.Instance.SmtpPassword))
            {
                client.Authenticate(
                    ApexnetMailSettingsReference.Instance.SmtpUsername,
                    ApexnetMailSettingsReference.Instance.SmtpPassword);
            }

            client.Send(mailMessage);
            client.Disconnect(true);
        }

        public void Dispose()
        {
            ((IDisposable)this.smtpClient).Dispose();
        }
    }
}