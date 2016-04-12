namespace Apexnet.Dispatch.Api.Controllers
{
    using System;
    using System.Web.Http;
    using Apexnet.JobQueue;
    using Common.Annotations;

    public class JobsController : BaseApiController
    {
        [UsedImplicitly]
        public JobsController()
            : this(null)
        {
        }

        private JobsController(IJobsManager jobsManager)
            : base(jobsManager)
        {
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var result = this.JobsManager.Delete(id);

            return result ? (IHttpActionResult)this.Ok() : this.NotFound();
        }
    }
}