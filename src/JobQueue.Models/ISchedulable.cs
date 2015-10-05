namespace Apexnet.JobQueue
{
    using System;

    public interface ISchedulable
    {
        DateTimeOffset Schedule { get; }
    }
}