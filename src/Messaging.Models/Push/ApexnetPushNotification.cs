namespace Apexnet.Messaging.Push
{
    public class ApexnetPushNotification
    {
        public string AuthKey { get; set; }

        public string AppKey { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public string Sound { get; set; }

        public int BadgeCount { get; set; }
    }
}