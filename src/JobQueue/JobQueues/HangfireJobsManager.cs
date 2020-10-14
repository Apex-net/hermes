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
            result.Id = jobId;
        }

        public TScheduled Schedule<TSchedulable, TScheduled>(TSchedulable job)
            where TSchedulable : IQueueable, ISchedulable
            where TScheduled : IScheduled
        {
            var jobId = BackgroundJob.Schedule(job.Operation, job.Schedule);

            var result = (TScheduled)Activator.CreateInstance(typeof(TScheduled));
            result.Id = jobId;
            result.Schedule = job.Schedule;

            return result;
        }

        public TEnqueued Recur<TRecurring, TEnqueued>(TRecurring job)
            where TRecurring : IQueueable, IRecurring
            where TEnqueued : IEnqueued
        {
            var jobId = Guid.NewGuid();

            RecurringJob.AddOrUpdate(jobId.ToString(), job.Operation, job.CronExpression);

            var result = (TEnqueued)Activator.CreateInstance(typeof(TEnqueued));
            result.Id = jobId.ToString();

            return result;
        }

        public bool Delete(Guid id)
        {
            var jobId = id.ToString();

            return TryDeleteBackgroundJob(jobId) || TryDeleteRecurringJob(jobId);
        }

        #region /// internal ///////////////////////////////////////////////////

        private static bool TryDeleteBackgroundJob(string jobId)
        {
            return BackgroundJob.Delete(jobId);
        }

        private static bool TryDeleteRecurringJob(string jobId)
        {
            RecurringJob.RemoveIfExists(jobId);
            return true;
        }

        #endregion
    }
}