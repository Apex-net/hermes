namespace Apexnet.Dispatch.Api
{
    using System.Web;
    using System.Web.Http;
    using Common.WebApi;
    using Elmah.Contrib.WebApi;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Filters.Add(new ElmahHandleErrorApiAttribute());

            GlobalConfiguration.Configure(WebApiConfig.Register);

            DefaultWebApiConfig.Register("dispatch", "0", GlobalConfiguration.Configuration);
        }
    }
}