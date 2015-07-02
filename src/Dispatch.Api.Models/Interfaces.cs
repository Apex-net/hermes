namespace Dispatch.Api.Models
{
    using System;
    using System.Linq.Expressions;

    public interface IQueueable
    {
        Expression<Action> Job { get; set; }
    }

    public interface ISchedulable : IQueueable
    {
        DateTimeOffset Schedule { get; set; }
    }

    public interface IScheduled
    {
        Guid Id { get; set; }

        DateTimeOffset Schedule { get; set; }
    }

    public interface IScheduler
    {
        IScheduled Schedule(ISchedulable schedulable);
    }
}