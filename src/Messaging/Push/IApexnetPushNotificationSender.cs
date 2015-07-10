namespace Apexnet.Messaging.Push
{
    public interface IApexnetPushNotificationSender
    {
        void Send(ApexnetPushNotification notification);
    }
}