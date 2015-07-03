namespace Apexnet.JobQueue
{
    using System;

    public interface IScheduled
    {
        Guid Id { get; set; }

        DateTimeOffset Schedule { get; set; }
    }
}