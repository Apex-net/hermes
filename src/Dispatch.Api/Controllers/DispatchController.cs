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
        private readonly IJobManager messageJobManager;

        #region TODO: replace with IoC container

        [UsedImplicitly]
        public DispatchController()
            : this(null)
        {
        }

        #endregion

        private DispatchController(IJobManager messageJobManager)
        {
            this.messageJobManager = messageJobManager ?? new HangfireJobManager();
        }

        [ResponseType(typeof(Scheduled))]
        public IHttpActionResult Post([FromBody] ScheduledBundle bundle)
        {
            var job = new ScheduledBundleJob(bundle);
            var scheduled = this.messageJobManager.Schedule<Scheduled>(job);

            return this.CreatedAtRoute("DefaultApi", new { controller = "messages", id = scheduled.Id }, scheduled);
        }
    }
}