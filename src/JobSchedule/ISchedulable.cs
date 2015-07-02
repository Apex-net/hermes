namespace Apexnet.JobSchedule
{
    using System;

    public interface ISchedulable : IQueueable
    {
        DateTimeOffset Schedule { get; set; }
    }
}