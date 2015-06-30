namespace Dispatch.Api.Models
{
    using System;
    using System.Collections.Generic;
    using Dispatch.Api.Models.DispatchTargets;

    public class Message
    {
        public Message()
        {
            this.Emails = new List<Email>();
        }

        public DateTime? Scheduled { get; set; }

        public IEnumerable<Email> Emails { get; set; }
    }
}