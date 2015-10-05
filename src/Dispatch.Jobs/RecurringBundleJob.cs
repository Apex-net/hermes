namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.Dispatch.Api;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;

    public class RecurringBundleJob : BaseBundleJob, IRecurring
    {
        private readonly RecurringBundleRequest request;

        public RecurringBundleJob(RecurringBundleRequest request)
            : base(new HangfireJobsManager())
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