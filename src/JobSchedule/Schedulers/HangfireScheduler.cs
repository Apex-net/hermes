namespace Apexnet.JobSchedule.Schedulers
{
    using System;
    using Apexnet.JobSchedule;
    using Hangfire;

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