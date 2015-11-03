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

        public Expression<Action> Operation
        {
            get
            {
                return () => _Run(this.pushNotification);
            }
        }

        //// ReSharper disable MemberCanBePrivate.Global
        public static void _Run(ApexnetPushNotification notification)
        {
            var sender = new ApexnetPushNotificationSender();
            sender.Send(notification);
        }

        //// ReSharper restore MemberCanBePrivate.Global
    }
}