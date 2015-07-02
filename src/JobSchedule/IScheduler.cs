namespace Apexnet.JobSchedule
{
    public interface IScheduler
    {
        IScheduled Schedule(ISchedulable schedulable);
    }
}