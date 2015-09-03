namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.Dispatch.Api;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;
    using Apexnet.Messaging.Mail;
    using Apexnet.Messaging.Push;
    using Common.Utils;

    public class ScheduledBundleJob : ISchedulable
    {
        private readonly ScheduledBundle bundle;

        private ScheduledBundleJob(ScheduledBundle bundle)
        {
            this.bundle = bundle;
        }

        public Expression<Action> Job
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
                return this.bundle.Schedule;
            }
        }

        public static ScheduledBundleJob FromScheduledBundle(ScheduledBundle bundle)
        {
            return new ScheduledBundleJob(bundle);
        }

        //// ReSharper disable MemberCanBePrivate.Global
        public static void ScheduleBundle(ScheduledBundle bundle)
        {
            var queue = new HangfireJobQueue<Enqueued, Scheduled>();

            bundle.MailMessages.Each((message, i) => Send(message, queue));
            bundle.ApexnetPushNotifications.Each((notification, i) => Send(notification, queue));
        }
        //// ReSharper restore MemberCanBePrivate.Global

        #region /// internal ///////////////////////////////////////////////////

        private static void Send(MailMessage mailMessage, IJobQueue queue)
        {
            var job = MailMessageJob.FromMailMessage(mailMessage);
            queue.Enqueue(job);
        }

        private static void Send(ApexnetPushNotification pushNotification, IJobQueue queue)
        {
            var job = ApexnetPushNotificationJob.FromApexnetPushNotification(pushNotification);
            queue.Enqueue(job);
        }

        #endregion
    }
}