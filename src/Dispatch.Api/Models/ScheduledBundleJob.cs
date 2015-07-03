namespace Apexnet.Dispatch.Api.Models
{
    using System;
    using System.Linq.Expressions;
    using System.Net.Mail;
    using Apexnet.Dispatch.Api.Bundle;
    using Apexnet.JobQueue;
    using Common.Utils;
    using Hangfire;
    using MailAddress = System.Net.Mail.MailAddress;
    using MailMessage = Apexnet.Dispatch.Api.Mail.MailMessage;

    public class ScheduledBundleJob : ISchedulable
    {
        private readonly ScheduledBundle bundle;

        private ScheduledBundleJob(ScheduledBundle bundle)
        {
            this.bundle = bundle;
        }

        Expression<Action> IQueueable.Job
        {
            get
            {
                return () => Foo(this.bundle);
            }
        }

        public DateTimeOffset Schedule
        {
            get
            {
                return this.bundle.Schedule ?? DateTime.Now;
            }
        }

        public static ScheduledBundleJob FromScheduledBundle(ScheduledBundle bundle)
        {
            return new ScheduledBundleJob(bundle);
        }

        public static void Foo(ScheduledBundle bundle)
        {
            bundle.MailMessages.Each((message, i) => BackgroundJob.Enqueue(() => Bar(message)));
        }

        public static void Bar(MailMessage message)
        {
            var mailMessage = new System.Net.Mail.MailMessage
            {
                From = new MailAddress(message.From.Address, message.From.DisplayName),
            };

            message.To.Each((x, i) => mailMessage.To.Add(new MailAddress(x.Address, x.DisplayName)));
            message.Cc.Each((x, i) => mailMessage.CC.Add(new MailAddress(x.Address, x.DisplayName)));
            message.Bcc.Each((x, i) => mailMessage.Bcc.Add(new MailAddress(x.Address, x.DisplayName)));

            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;

            var client = new SmtpClient();
            client.Send(mailMessage);
        }
    }
}