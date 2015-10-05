namespace Apexnet.JobQueue.JobQueues
{
    using System;
    using Hangfire;

    public class HangfireJobsManager : IJobsManager
    {
        public void Enqueue<TEnqueued>(IQueueable job) where TEnqueued : IEnqueued
        {
            var jobId = BackgroundJob.Enqueue(job.Operation);

            var result = (IEnqueued)Activator.CreateInstance(typeof(TEnqueued));
            result.Id = Guid.Parse(jobId);
        }

        public TScheduled Schedule<TSchedulable, TScheduled>(TSchedulable job)
            where TSchedulable : IQueueable, ISchedulable
            where TScheduled : IScheduled
        {
            var jobId = BackgroundJob.Schedule(job.Operation, job.Schedule);

            var result = (TScheduled)Activator.CreateInstance(typeof(TScheduled));
            result.Id = Guid.Parse(jobId);
            result.Schedule = job.Schedule;

            return result;
        }

        public TEnqueued Recur<TRecurring, TEnqueued>(TRecurring job)
            where TRecurring : IRecurring
            where TEnqueued : IEnqueued
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            return BackgroundJob.Delete(id.ToString());
        }
    }
}