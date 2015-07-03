namespace Apexnet.Dispatch.Api
{
    using System;
    using Apexnet.Dispatch.Api.Annotations;
    using Apexnet.JobQueue;
    using Newtonsoft.Json;

    [UsedImplicitly]
    public class ScheduledMessage : IScheduled
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public DateTimeOffset Schedule { get; set; }
    }
}