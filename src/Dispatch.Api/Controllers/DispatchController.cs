namespace Apexnet.Dispatch.Api.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Description;
    using Apexnet.Dispatch.Jobs;
    using Apexnet.JobQueue;
    using Common.Annotations;

    public class DispatchController : BaseApiController
    {
        #region TODO: replace with IoC container

        [UsedImplicitly]
        public DispatchController()
            : this(null)
        {
        }

        private DispatchController(IJobsManager jobsManager)
            : base(jobsManager)
        {
        }

        #endregion

        [ResponseType(typeof(ScheduledResponse))]
        public IHttpActionResult Post([FromBody] ScheduledBundleRequest request)
        {
            var job = new ScheduledBundleJob(request);
            var response = this.JobsManager.Schedule<ScheduledResponse>(job);

            return this.CreatedAtRoute("DefaultApi", new { controller = "jobs", id = response.Id }, response);
        }
    }
}