namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.JobQueue;
    using Apexnet.Messaging.Mail;

    public class MailMessageJob : IQueueable
    {
        private readonly MailMessage mailMessage;

        public MailMessageJob(MailMessage mailMessage)
        {
            this.mailMessage = mailMessage;
        }

        public Expression<Action> Operation
        {
            get
            {
                return () => _Run(this.mailMessage);
            }
        }

        //// ReSharper disable MemberCanBePrivate.Global
        public static void _Run(MailMessage message)
        {
            var sender = new MailMessageSender();
            sender.Send(message);
        }

        //// ReSharper restore MemberCanBePrivate.Global
    }
}