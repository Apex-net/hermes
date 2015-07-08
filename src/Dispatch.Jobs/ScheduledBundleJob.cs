namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.Dispatch.Api;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;
    using Apexnet.Messaging.Mail;
    using Common.Utils;

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
                return () => ScheduleBundle(this.bundle);
            }
        }

        public DateTimeOffset Schedule
        {
            get
            {
                return this.bundle.Schedule ?? DateTime.Now;
            }

            set
            {
                this.bundle.Schedule = value;
            }
        }

        public static ScheduledBundleJob FromScheduledBundle(ScheduledBundle bundle)
        {
            return new ScheduledBundleJob(bundle);
        }

        // ReSharper disable MemberCanBePrivate.Global
        public static void ScheduleBundle(ScheduledBundle bundle)
        {
            var queue = new HangfireJobQueue<Enqueued, Scheduled>();

            bundle.MailMessages.Each((message, i) => Send(message, queue));
        }

        // ReSharper restore MemberCanBePrivate.Global
        ////
        private static void Send(MailMessage mailMessage, IJobQueue queue)
        {
            var messageJob = MailMessageJob.FromMailMessage(mailMessage);
            queue.Enqueue(messageJob);
        }
    }
}