namespace Apexnet.Messaging.ApexnetPushServiceReference
{
    using Apexnet.Messaging.Configuration;

    public partial class Notificatore
    {
        public static Notificatore InstanceFromCustomConfiguration()
        {
            return new Notificatore { Url = ApexnetPushServiceReference.Instance.Url };
        }
    }
}