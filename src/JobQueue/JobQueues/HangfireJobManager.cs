namespace Apexnet.JobQueue.JobQueues
{
    using System;
    using Hangfire;

    public class HangfireJobManager : IJobManager
    {
        public void Enqueue<TEnqueued>(IQueueable queueable) where TEnqueued : IEnqueued
        {
            var jobId = BackgroundJob.Enqueue(queueable.Job);

            var result = (IEnqueued)Activator.CreateInstance(typeof(TEnqueued));
            result.Id = Guid.Parse(jobId);
        }

        public IScheduled Schedule<TScheduled>(ISchedulable schedulable) where TScheduled : IScheduled
        {
            var jobId = BackgroundJob.Schedule(schedulable.Job, schedulable.Schedule);

            var result = (IScheduled)Activator.CreateInstance(typeof(TScheduled));
            result.Id = Guid.Parse(jobId);
            result.Schedule = schedulable.Schedule;

            return result;
        }

        public bool Delete(Guid id)
        {
            return BackgroundJob.Delete(id.ToString());
        }
    }
}