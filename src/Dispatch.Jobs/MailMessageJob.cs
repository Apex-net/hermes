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

        Expression<Action> IQueueable.Job
        {
            get
            {
                return () => Send(this.mailMessage);
            }
        }

        public static MailMessageJob FromMailMessage(MailMessage bundle)
        {
            return new MailMessageJob(bundle);
        }

        // ReSharper disable MemberCanBePrivate.Global
        public static void Send(MailMessage message)
        {
            var sender = new MailMessageSender();
            sender.Send(message);
        }

        // ReSharper restore MemberCanBePrivate.Global
        ////
    }
}