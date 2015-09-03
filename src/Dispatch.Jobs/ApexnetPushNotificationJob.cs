namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.JobQueue;
    using Apexnet.Messaging.Push;

    public class ApexnetPushNotificationJob : IQueueable
    {
        private readonly ApexnetPushNotification pushNotification;

        public ApexnetPushNotificationJob(ApexnetPushNotification pushNotification)
        {
            this.pushNotification = pushNotification;
        }

        public Expression<Action> Job
        {
            get
            {
                return () => _Send(this.pushNotification);
            }
        }

        //// ReSharper disable MemberCanBePrivate.Global
        public static void _Send(ApexnetPushNotification notification)
        {
            var sender = new ApexnetPushNotificationSender();
            sender.Send(notification);
        }

        //// ReSharper restore MemberCanBePrivate.Global
    }
}