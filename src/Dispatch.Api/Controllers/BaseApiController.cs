namespace Apexnet.Dispatch.Api.Controllers
{
    using System.Web.Http;
    using Apexnet.JobQueue;
    using Apexnet.JobQueue.JobQueues;

    public abstract class BaseApiController : ApiController
    {
        protected readonly IJobsManager JobsManager;

        protected BaseApiController(IJobsManager jobsManager)
        {
            this.JobsManager = jobsManager ?? new HangfireJobsManager();
        }
    }
}