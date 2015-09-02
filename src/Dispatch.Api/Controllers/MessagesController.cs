namespace Apexnet.Dispatch.Api.Controllers
{
    using System;
    using System.Web.Http;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;
    using Common.Annotations;

    public class MessagesController : ApiController
    {
        private readonly IJobQueue messageJobQueue;

        #region TODO: replace with IoC container

        [UsedImplicitly]
        public MessagesController()
            : this(null)
        {
        }

        #endregion

        private MessagesController(IJobQueue messageJobQueue)
        {
            this.messageJobQueue = messageJobQueue ?? new HangfireJobQueue<Enqueued, Scheduled>();
        }

        public IHttpActionResult Delete(Guid id)
        {
            var result = this.messageJobQueue.Delete(id);

            return result ? (IHttpActionResult)this.Ok() : this.NotFound();
        }
    }
}