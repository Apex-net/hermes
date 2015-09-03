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

        public ScheduledBundleJob(ScheduledBundle bundle)
        {
            this.bundle = bundle;
        }

        public Expression<Action> Job
        {
            get
            {
                return () => _Schedule(this.bundle);
            }
        }

        public DateTimeOffset Schedule
        {
            get
            {
                return this.bundle.Schedule;
            }
        }

        //// ReSharper disable MemberCanBePrivate.Global
        public static void _Schedule(ScheduledBundle bundle)
        {
            var queue = new HangfireJobManager();

            bundle.MailMessages.Each((message, i) => Send(message, queue));
            bundle.ApexnetPushNotifications.Each((notification, i) => Send(notification, queue));
        }

        //// ReSharper restore MemberCanBePrivate.Global
        #region /// internal ///////////////////////////////////////////////////

        private static void Send(MailMessage mailMessage, IJobManager manager)
        {
            var job = new MailMessageJob(mailMessage);
            manager.Enqueue<Enqueued>(job);
        }

        private static void Send(ApexnetPushNotification pushNotification, IJobManager manager)
        {
            var job = new ApexnetPushNotificationJob(pushNotification);
            manager.Enqueue<Enqueued>(job);
        }

        #endregion
    }
}