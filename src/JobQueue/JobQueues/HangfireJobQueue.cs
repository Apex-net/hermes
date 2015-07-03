namespace Apexnet.JobQueue.JobQueues
{
    using System;
    using Hangfire;

    public class HangfireJobQueue<TScheduled> : IJobQueue
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