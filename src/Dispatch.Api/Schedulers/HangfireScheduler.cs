namespace Dispatch.Api.Schedulers
{
    using System;
    using Dispatch.Api.Models;
    using global::Hangfire;

    public class HangfireScheduler<TScheduled> : IScheduler
    {
        public IScheduled Schedule(ISchedulable schedulable)
        {
            var jobId = BackgroundJob.Schedule(schedulable.Job, schedulable.Schedule);

            var result = (IScheduled)Activator.CreateInstance(typeof(TScheduled));
            result.Id = Guid.Parse(jobId);
            result.Schedule = schedulable.Schedule;

            return result;
        }
    }
}