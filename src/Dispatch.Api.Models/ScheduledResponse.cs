namespace Apexnet.Dispatch.Api
{
    using System;
    using Apexnet.JobQueue;

    public class ScheduledResponse : IScheduled
    {
        public Guid Id { get; set; }

        public DateTimeOffset Schedule { get; set; }
    }
}