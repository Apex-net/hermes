namespace Apexnet.JobQueue
{
    using System;

    public interface IEnqueued : IQueueable
    {
        Guid Id { get; set; }
    }
}