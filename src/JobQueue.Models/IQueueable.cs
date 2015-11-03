namespace Apexnet.JobQueue
{
    using System;
    using System.Linq.Expressions;

    public interface IQueueable
    {
        Expression<Action> Operation { get; }
    }
}