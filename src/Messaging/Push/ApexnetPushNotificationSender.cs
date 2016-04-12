namespace Apexnet.Messaging.Push
{
    using System;
    using Apexnet.Messaging.ApexnetPushServiceReference;

    public class ApexnetPushNotificationSender : IDisposable
    {
        private readonly Notificatore notificatore;

        public ApexnetPushNotificationSender()
            : this(null)
        {
        }

        private ApexnetPushNotificationSender(Notificatore notificatore)
        {
            this.notificatore = notificatore ?? Notificatore.InstanceFromCustomConfiguration();
        }

        public void Send(ApexnetPushNotification notification)
        {
            this.notificatore.SendPush(
                notification.AuthKey,
                notification.AppKey,
                notification.Message,
                notification.UserName,
                notification.Sound,
                notification.CustomField1,
                notification.CustomField2,
                notification.BadgeCount);
        }

        public void Dispose()
        {
            ((IDisposable)this.notificatore).Dispose();
        }
    }
}