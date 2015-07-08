namespace Apexnet.JobQueue
{
    using System;

    public interface IScheduled : ISchedulable
    {
        Guid Id { get; set; }
    }
}