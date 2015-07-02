namespace Dispatch.Api.Controllers
{
    using System.Web.Http;
    using Dispatch.Api.Models;
    using Dispatch.Api.Schedulers;

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