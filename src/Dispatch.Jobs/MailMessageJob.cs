namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.JobQueue;
    using Apexnet.Messaging.Mail;

    public class MailMessageJob : IQueueable
    {
        private readonly MailMessage mailMessage;

        private MailMessageJob(MailMessage mailMessage)
        {
            this.mailMessage = mailMessage;
        }

        public Expression<Action> Job
        {
            get
            {
                return () => Send(this.mailMessage);
            }
        }

        public static MailMessageJob FromMailMessage(MailMessage message)
        {
            return new MailMessageJob(message);
        }

        //// ReSharper disable MemberCanBePrivate.Global
        public static void Send(MailMessage message)
        {
            IMailMessageSender sender = new MailMessageSender();
            sender.Send(message);
        }
        //// ReSharper restore MemberCanBePrivate.Global
    }
}