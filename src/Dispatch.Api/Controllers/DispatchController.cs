namespace Apexnet.Dispatch.Api.Controllers
{
    using System.Web.Http;
    using Apexnet.Dispatch.Api.Models;
    using Apexnet.JobSchedule;
    using Apexnet.JobSchedule.Schedulers;

    public class DispatchController : ApiController
    {
        private readonly IScheduler messageScheduler;

        public DispatchController()
            : this(null)
        {
        }

        public DispatchController(IScheduler messageScheduler)
        {
            this.messageScheduler = messageScheduler ?? new HangfireScheduler<ScheduledMessage>();
        }

        public IHttpActionResult Post([FromBody] Message message)
        {
            var schedulable = SchedulableMessage.FromMessage(message);
            var scheduled = this.messageScheduler.Schedule(schedulable);

            return this.CreatedAtRoute("DefaultApi", new { controller = "messages", id = scheduled.Id }, scheduled);
        }
    }
}