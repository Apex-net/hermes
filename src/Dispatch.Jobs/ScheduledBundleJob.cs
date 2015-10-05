namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.Dispatch.Api;
    using Apexnet.Dispatch.Api.Annotations;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;

    public class ScheduledBundleJob : BaseBundleJob<ScheduledBundleRequest>, ISchedulable
    {
        private readonly ScheduledBundleRequest request;

        [UsedImplicitly]
        public ScheduledBundleJob()
            : this(null, null)
        {
        }

        public ScheduledBundleJob(ScheduledBundleRequest request)
            : this(null, request)
        {
            this.request = request;
        }

        private ScheduledBundleJob(IJobsManager jobsManager, ScheduledBundleRequest request)
            : base(jobsManager ?? new HangfireJobsManager())
        {
            this.request = request;
        }

        public override Expression<Action> Operation
        {
            get
            {
                return () => this._Run(this.request);
            }
        }

        public DateTimeOffset Schedule
        {
            get
            {
                return this.request.Schedule;
            }
        }
    }
}