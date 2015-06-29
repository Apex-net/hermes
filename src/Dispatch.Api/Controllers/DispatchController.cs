namespace Dispatch.Api.Controllers
{
    using System.Web.Http;
    using Dispatch.Api.Models;

    public class DispatchController : ApiController
    {
        public void Post([FromBody] Message message)
        {
        }
    }
}