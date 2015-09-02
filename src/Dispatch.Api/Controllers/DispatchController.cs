namespace Apexnet.Dispatch.Api.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Description;
    using Apexnet.Dispatch.Jobs;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;
    using Common.Annotations;

    public class DispatchController : ApiController
    {
        private readonly IJobQueue messageJobQueue;

        #region TODO: replace with IoC container

        [UsedImplicitly]
        public DispatchController()
            : this(null)
        {
        }

        #endregion

        private DispatchController(IJobQueue messageJobQueue)
        {
            this.messageJobQueue = messageJobQueue ?? new HangfireJobQueue<Enqueued, Scheduled>();
        }

        [ResponseType(typeof(Scheduled))]
        public IHttpActionResult Post([FromBody] ScheduledBundle bundle)
        {
            var job = ScheduledBundleJob.FromScheduledBundle(bundle);
            var scheduled = this.messageJobQueue.Schedule(job);

            return this.CreatedAtRoute("DefaultApi", new { controller = "messages", id = scheduled.Id }, scheduled);
        }
    }
}