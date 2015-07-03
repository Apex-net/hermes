namespace Apexnet.Dispatch.Api.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Apexnet.Dispatch.Api.Mail;

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