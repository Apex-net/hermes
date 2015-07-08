namespace Apexnet.JobQueue
{
    using System;

    public interface ISchedulable : IQueueable
    {
        DateTimeOffset Schedule { get; set; }
    }
}