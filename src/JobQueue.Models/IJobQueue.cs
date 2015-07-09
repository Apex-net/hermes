namespace Apexnet.JobQueue
{
    using System;

    public interface IJobQueue
    {
        IEnqueued Enqueue(IQueueable queueable);

        IScheduled Schedule(ISchedulable schedulable);

        bool Delete(Guid id);
    }
}