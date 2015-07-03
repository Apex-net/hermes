namespace Apexnet.JobQueue
{
    public interface IJobQueue
    {
        IScheduled Schedule(ISchedulable schedulable);
    }
}