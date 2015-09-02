namespace Apexnet.Messaging.Push
{
    public class ApexnetPushNotification
    {
        public ApexnetPushNotification(
            string authKey,
            string appKey,
            string userName,
            string message,
            string sound = "",
            int badgeCount = 0)
        {
            this.AuthKey = authKey;
            this.AppKey = appKey;
            this.UserName = userName;

            this.Message = message;
            this.Sound = sound;
            this.BadgeCount = badgeCount;
        }

        public string AuthKey { get; private set; }

        public string AppKey { get; private set; }

        public string UserName { get; private set; }

        public string Message { get; private set; }

        public string Sound { get; private set; }

        public int BadgeCount { get; private set; }
    }
}