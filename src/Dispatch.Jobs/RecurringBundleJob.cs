namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.Dispatch.Api;
    using Apexnet.Dispatch.Api.Annotations;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;

    public class RecurringBundleJob : BaseBundleJob<RecurringBundleRequest>, IRecurring
    {
        private readonly RecurringBundleRequest request;

        [UsedImplicitly]
        public RecurringBundleJob()
            : this(null, null)
        {
        }

        public RecurringBundleJob(RecurringBundleRequest request)
            : this(null, request)
        {
            this.request = request;
        }

        private RecurringBundleJob(IJobsManager jobsManager, RecurringBundleRequest request)
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

        public string CronExpression
        {
            get
            {
                return this.request.CronExpression;
            }
        }
    }
}