namespace Apexnet.Dispatch.Api.Controllers
{
    using System.Web.Http;
    using Apexnet.Dispatch.Jobs;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;

    public class DispatchController : ApiController
    {
        private readonly IJobQueue messageJobQueue;

        #region TODO: replace with IoC container

        // ReSharper disable UnusedMember.Global
        public DispatchController()
            : this(null)
        {
        }

        // ReSharper restore UnusedMember.Global
        ////
        #endregion

        private DispatchController(IJobQueue messageJobQueue)
        {
            this.messageJobQueue = messageJobQueue ?? new HangfireJobQueue<Enqueued, Scheduled>();
        }

        public IHttpActionResult Post([FromBody] ScheduledBundle bundle)
        {
            var job = ScheduledBundleJob.FromScheduledBundle(bundle);
            var scheduled = this.messageJobQueue.Schedule(job);

            return this.CreatedAtRoute("DefaultApi", new { controller = "messages", id = scheduled.Id }, scheduled);
        }
    }
}