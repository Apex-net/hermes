namespace Apexnet.JobQueue
{
    public interface IRecurring
    {
        string CronExpression { get; }
    }
}