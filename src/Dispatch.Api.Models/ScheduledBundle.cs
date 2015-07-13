namespace Apexnet.Dispatch.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Apexnet.Messaging.Mail;
    using Apexnet.Messaging.Push;

    public class ScheduledBundle
    {
        public ScheduledBundle()
        {
            this.MailMessages = new Collection<MailMessage>();
            this.ApexnetPushNotifications = new Collection<ApexnetPushNotification>();
        }

        public DateTimeOffset? Schedule { get; set; }

        public ICollection<MailMessage> MailMessages { get; set; }

        public ICollection<ApexnetPushNotification> ApexnetPushNotifications { get; set; }
    }
}