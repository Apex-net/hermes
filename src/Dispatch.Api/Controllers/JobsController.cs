namespace Apexnet.Dispatch.Api.Controllers
{
    using System;
    using System.Web.Http;
    using Apexnet.JobQueue;
    using Common.Annotations;

    public class JobsController : BaseApiController
    {
        #region TODO: replace with IoC container

        [UsedImplicitly]
        public JobsController()
            : this(null)
        {
        }

        private JobsController(IJobsManager jobsManager)
            : base(jobsManager)
        {
        }

        #endregion

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var result = this.JobsManager.Delete(id);

            return result ? (IHttpActionResult)this.Ok() : this.NotFound();
        }
    }
}