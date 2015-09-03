namespace Apexnet.JobQueue
{
    using System;

    public interface IJobManager
    {
        void Enqueue<TEnqueued>(IQueueable queueable) where TEnqueued : IEnqueued;

        IScheduled Schedule<TScheduled>(ISchedulable schedulable) where TScheduled : IScheduled;

        bool Delete(Guid id);
    }
}