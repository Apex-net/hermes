namespace Apexnet.JobQueue.JobQueues
{
    using System;
    using Hangfire;

    public class HangfireJobQueue<TEnqueued, TScheduled> : IJobQueue
        where TEnqueued : IEnqueued
        where TScheduled : IScheduled
    {
        public IEnqueued Enqueue(IQueueable queueable)
        {
            var jobId = BackgroundJob.Enqueue(queueable.Job);

            var result = (IEnqueued)Activator.CreateInstance(typeof(TEnqueued));
            result.Id = Guid.Parse(jobId);

            return result;
        }

        public IScheduled Schedule(ISchedulable schedulable)
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