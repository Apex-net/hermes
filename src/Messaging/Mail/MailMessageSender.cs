namespace Apexnet.Messaging.Mail
{
    using System.Net.Mail;
    using Common.Utils;

    public class MailMessageSender : IMailMessageSender
    {
        private readonly SmtpClient smtpClient;

        #region TODO: replace with IoC container

        // ReSharper disable UnusedMember.Global
        public MailMessageSender()
            : this(null)
        {
        }

        // ReSharper restore UnusedMember.Global
        ////
        #endregion

        private MailMessageSender(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient ?? new SmtpClient();
        }

        public void Send(MailMessage message)
        {
            var mailMessage = new System.Net.Mail.MailMessage
            {
                From = new System.Net.Mail.MailAddress(message.From.Address, message.From.DisplayName),
            };

            message.To.Each((x, i) => mailMessage.To.Add(new System.Net.Mail.MailAddress(x.Address, x.DisplayName)));
            message.Cc.Each((x, i) => mailMessage.CC.Add(new System.Net.Mail.MailAddress(x.Address, x.DisplayName)));
            message.Bcc.Each((x, i) => mailMessage.Bcc.Add(new System.Net.Mail.MailAddress(x.Address, x.DisplayName)));

            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;
            mailMessage.IsBodyHtml = message.IsBodyHtml;

            this.smtpClient.Send(mailMessage);
        }
    }
}