namespace Apexnet.JobSchedule
{
    using System;
    using System.Linq.Expressions;

    public interface IQueueable
    {
        Expression<Action> Job { get; }
    }
}