namespace Apexnet.Dispatch.Api
{
    using System;
    using Apexnet.JobQueue;

    public class Scheduled : IScheduled
    {
        public Guid Id { get; set; }

        public DateTimeOffset Schedule { get; set; }
    }
}