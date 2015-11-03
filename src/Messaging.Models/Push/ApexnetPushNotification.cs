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
            string customField1 = "",
            string customField2 = "",
            int badgeCount = 0)
        {
            this.AuthKey = authKey;
            this.AppKey = appKey;
            this.UserName = userName;

            this.Message = message;
            this.Sound = sound;
            this.CustomField1 = customField1;
            this.CustomField2 = customField2;
            this.BadgeCount = badgeCount;
        }

        public string AuthKey { get; private set; }

        public string AppKey { get; private set; }

        public string UserName { get; private set; }

        public string Message { get; private set; }

        public string Sound { get; private set; }

        public string CustomField1 { get; private set; }

        public string CustomField2 { get; private set; }

        public int BadgeCount { get; private set; }
    }
}