namespace Dispatch.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class Message
    {
        public DateTimeOffset? Schedule { get; set; }

        public IEnumerable<Email> Emails { get; set; }
    }
}