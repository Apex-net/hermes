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
        private readonly ScheduledBundleRequest scheduledBundleRequest;

        public ScheduledBundleJob(ScheduledBundleRequest scheduledBundleRequest)
        {
            this.scheduledBundleRequest = scheduledBundleRequest;
        }

        public Expression<Action> Job
        {
            get
            {
                return () => _Schedule(this.scheduledBundleRequest);
            }
        }

        public DateTimeOffset Schedule
        {
            get
            {
                return this.scheduledBundleRequest.Schedule;
            }
        }

        //// ReSharper disable MemberCanBePrivate.Global
        public static void _Schedule(ScheduledBundleRequest scheduledBundleRequest)
        {
            var queue = new HangfireJobsManager();

            scheduledBundleRequest.MailMessages.Each((message, i) => Send(message, queue));
            scheduledBundleRequest.ApexnetPushNotifications.Each((notification, i) => Send(notification, queue));
        }

        //// ReSharper restore MemberCanBePrivate.Global
        #region /// internal ///////////////////////////////////////////////////

        private static void Send(MailMessage mailMessage, IJobsManager manager)
        {
            var job = new MailMessageJob(mailMessage);
            manager.Enqueue<Enqueued>(job);
        }

        private static void Send(ApexnetPushNotification pushNotification, IJobsManager manager)
        {
            var job = new ApexnetPushNotificationJob(pushNotification);
            manager.Enqueue<Enqueued>(job);
        }

        #endregion
    }
}