namespace Apexnet.Dispatch.Api.Models
{
    using System;
    using Apexnet.JobSchedule;
    using Newtonsoft.Json;

    public class ScheduledMessage : IScheduled
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public DateTimeOffset Schedule { get; set; }
    }
}