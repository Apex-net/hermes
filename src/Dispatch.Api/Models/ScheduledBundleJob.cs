namespace Apexnet.Dispatch.Api.Models
{
    using System;
    using System.Linq.Expressions;
    using System.Net.Mail;
    using Apexnet.Dispatch.Api.Bundle;
    using Apexnet.JobSchedule;

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
                return () => Foo();
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

        // ReSharper disable once MemberCanBePrivate.Global
        public static void Foo()
        {
            var message = new MailMessage { From = new MailAddress("a.donmez@apexnet.it", "Ali Servet Donmez") };
            message.To.Add(new MailAddress("s.teodorani@apexnet.it", "Stefano Teodorani"));
            message.CC.Add(new MailAddress("a.calisesi@apexnet.it", "Andrea Calisesi"));
            message.Bcc.Add(new MailAddress("a.donmez@apexnet.it", "Ali Servet Donmez"));
            message.Body = "It, Works!";

            var client = new SmtpClient();
            client.SendMailAsync(message);
        }
    }
}