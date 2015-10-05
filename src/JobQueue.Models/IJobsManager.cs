namespace Apexnet.JobQueue
{
    using System;

    public interface IJobsManager
    {
        void Enqueue<TEnqueued>(IQueueable job) where TEnqueued : IEnqueued;

        TScheduled Schedule<TSchedulable, TScheduled>(TSchedulable job)
            where TSchedulable : IQueueable, ISchedulable
            where TScheduled : IScheduled;

        TEnqueued Recur<TRecurring, TEnqueued>(TRecurring job)
            where TRecurring : IRecurring
            where TEnqueued : IEnqueued;

        bool Delete(Guid id);
    }
}