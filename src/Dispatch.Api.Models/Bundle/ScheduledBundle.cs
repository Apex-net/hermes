namespace Apexnet.Dispatch.Api.Bundle
{
    using System;
    using System.Collections.Generic;
    using Apexnet.Dispatch.Api.Mail;

    public class ScheduledBundle
    {
        public DateTimeOffset? Schedule { get; set; }

        public IEnumerable<MailMessage> MailMessages { get; set; }
    }
}