namespace Dispatch.Api.Controllers
{
    using System;
    using System.Web.Http;
    using Dispatch.Api.Models;

    public class DispatchController : ApiController
    {
        public IHttpActionResult Post([FromBody] Message message)
        {
            Finalize(message);

            return this.CreatedAtRoute("DefaultApi", new { controller = "messages", id = Guid.NewGuid() }, message);
        }

        #region /// internal ///////////////////////////////////////////////////

        private static void Finalize(Message message)
        {
            message.Scheduled = message.Scheduled ?? DateTime.Now;
        }

        #endregion
    }
}