namespace Apexnet.JobQueue
{
    using System;

    public interface IScheduled : IEnqueued
    {
        DateTimeOffset Schedule { set; }
    }
}