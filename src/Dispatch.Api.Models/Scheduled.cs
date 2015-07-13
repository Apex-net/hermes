namespace Apexnet.Dispatch.Api
{
    using System;
    using Apexnet.JobQueue;

    // ReSharper disable ClassNeverInstantiated.Global
    public class Scheduled : IScheduled
    {
        public Guid Id { get; set; }

        public DateTimeOffset Schedule { get; set; }
    }

    // ReSharper restore ClassNeverInstantiated.Global
}