namespace Apexnet.Dispatch.Api.Controllers
{
    using System.Web.Http;
    using Apexnet.Dispatch.Api.Bundle;
    using Apexnet.Dispatch.Api.Models;
    using Apexnet.JobSchedule;
    using Apexnet.JobSchedule.Schedulers;
    using Common.Annotations;

    public class DispatchController : ApiController
    {
        private readonly IScheduler messageScheduler;

        [UsedImplicitly]
        public DispatchController()
            : this(null)
        {
        }

        private DispatchController(IScheduler messageScheduler)
        {
            this.messageScheduler = messageScheduler ?? new HangfireScheduler<ScheduledMessage>();
        }

        public IHttpActionResult Post([FromBody] ScheduledBundle bundle)
        {
            var job = ScheduledBundleJob.FromScheduledBundle(bundle);
            var scheduled = this.messageScheduler.Schedule(job);

            return this.CreatedAtRoute("DefaultApi", new { controller = "messages", id = scheduled.Id }, scheduled);
        }
    }
}