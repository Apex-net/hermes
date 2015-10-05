namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.Dispatch.Api;
    using Apexnet.JobQueue;
    using Apexnet.Messaging.Http;
    using Apexnet.Messaging.Mail;
    using Apexnet.Messaging.Push;
    using Common.Utils;

    public abstract class BaseBundleJob<TRequest> : IQueueable
        where TRequest : IBundleRequest
    {
        private readonly IJobsManager hangfireJobsManager;

        protected BaseBundleJob(IJobsManager jobsManager)
        {
            this.hangfireJobsManager = jobsManager;
        }

        public abstract Expression<Action> Operation { get; }

        // ReSharper disable MemberCanBeProtected.Global
        public void _Run(TRequest request)
        {
            request.MailMessages.Each((message, i) => Send(message, this.hangfireJobsManager));
            request.HttpRequests.Each((req, i) => Send(req, this.hangfireJobsManager));
            request.ApexnetPushNotifications.Each((notification, i) => Send(notification, this.hangfireJobsManager));
        }

        // ReSharper restore MemberCanBeProtected.Global
        #region /// internal ///////////////////////////////////////////////////

        private static void Send(MailMessage mailMessage, IJobsManager manager)
        {
            var job = new MailMessageJob(mailMessage);
            manager.Enqueue<Enqueued>(job);
        }

        private static void Send(HttpRequestMessage httpRequestMessage, IJobsManager manager)
        {
            var job = new HttpRequestJob(httpRequestMessage);
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