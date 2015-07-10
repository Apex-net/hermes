namespace Apexnet.Dispatch.Api.Controllers
{
    using System;
    using System.Web.Http;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;

    public class MessagesController : ApiController
    {
        private readonly IJobQueue messageJobQueue;

        #region TODO: replace with IoC container

        // ReSharper disable UnusedMember.Global
        public MessagesController()
            : this(null)
        {
        }

        // ReSharper restore UnusedMember.Global
        ////
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