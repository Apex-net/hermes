namespace Apexnet.Messaging.Push
{
    using Apexnet.Messaging.ApexnetPushServiceReference;

    public class ApexnetPushNotificationSender : IApexnetPushNotificationSender
    {
        private readonly Notificatore notificatore;

        #region TODO: replace with IoC container

        // ReSharper disable UnusedMember.Global
        public ApexnetPushNotificationSender()
            : this(null)
        {
        }

        // ReSharper restore UnusedMember.Global
        ////
        #endregion

        private ApexnetPushNotificationSender(Notificatore notificatore)
        {
            this.notificatore = notificatore ?? new Notificatore();
        }

        public void Send(ApexnetPushNotification notification)
        {
            this.notificatore.SendNotification(
                notification.AuthKey,
                notification.AppKey,
                notification.Message,
                notification.UserName,
                notification.Sound,
                notification.BadgeCount);
        }
    }
}