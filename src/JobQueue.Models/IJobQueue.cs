namespace Apexnet.JobQueue
{
    public interface IJobQueue
    {
        IEnqueued Enqueue(IQueueable queueable);

        IScheduled Schedule(ISchedulable schedulable);
    }
}