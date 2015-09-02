namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.JobQueue;
    using Apexnet.Messaging.Push;

    public class ApexnetPushNotificationJob : IQueueable
    {
        private readonly ApexnetPushNotification pushNotification;

        private ApexnetPushNotificationJob(ApexnetPushNotification pushNotification)
        {
            this.pushNotification = pushNotification;
        }

        Expression<Action> IQueueable.Job
        {
            get
            {
                return () => Send(this.pushNotification);
            }
        }

        public static ApexnetPushNotificationJob FromApexnetPushNotification(ApexnetPushNotification notification)
        {
            return new ApexnetPushNotificationJob(notification);
        }

        //// ReSharper disable MemberCanBePrivate.Global
        public static void Send(ApexnetPushNotification notification)
        {
            IApexnetPushNotificationSender sender = new ApexnetPushNotificationSender();
            sender.Send(notification);
        }
        //// ReSharper restore MemberCanBePrivate.Global
    }
}