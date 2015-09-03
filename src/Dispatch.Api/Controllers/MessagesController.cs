namespace Apexnet.Dispatch.Api.Controllers
{
    using System;
    using System.Web.Http;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;
    using Common.Annotations;

    public class MessagesController : ApiController
    {
        private readonly IJobManager messageJobManager;

        #region TODO: replace with IoC container

        [UsedImplicitly]
        public MessagesController()
            : this(null)
        {
        }

        #endregion

        private MessagesController(IJobManager messageJobManager)
        {
            this.messageJobManager = messageJobManager ?? new HangfireJobManager();
        }

        public IHttpActionResult Delete(Guid id)
        {
            var result = this.messageJobManager.Delete(id);

            return result ? (IHttpActionResult)this.Ok() : this.NotFound();
        }
    }
}