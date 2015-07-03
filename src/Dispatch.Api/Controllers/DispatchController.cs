namespace Apexnet.Dispatch.Api.Controllers
{
    using System.Web.Http;
    using Apexnet.Dispatch.Api.Bundle;
    using Apexnet.Dispatch.Api.Models;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;
    using Common.Annotations;

    public class DispatchController : ApiController
    {
        private readonly IJobQueue messageJobQueue;

        [UsedImplicitly]
        public DispatchController()
            : this(null)
        {
        }

        private DispatchController(IJobQueue messageJobQueue)
        {
            this.messageJobQueue = messageJobQueue ?? new HangfireJobQueue<ScheduledMessage>();
        }

        public IHttpActionResult Post([FromBody] ScheduledBundle bundle)
        {
            var job = ScheduledBundleJob.FromScheduledBundle(bundle);
            var scheduled = this.messageJobQueue.Schedule(job);

            return this.CreatedAtRoute("DefaultApi", new { controller = "messages", id = scheduled.Id }, scheduled);
        }
    }
}