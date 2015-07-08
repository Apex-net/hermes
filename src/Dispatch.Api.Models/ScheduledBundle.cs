namespace Apexnet.Dispatch.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Apexnet.Messaging.Mail;

    public class ScheduledBundle
    {
        public ScheduledBundle()
        {
            this.MailMessages = new Collection<MailMessage>();
        }

        public DateTimeOffset? Schedule { get; set; }

        public IEnumerable<MailMessage> MailMessages { get; set; }
    }
}