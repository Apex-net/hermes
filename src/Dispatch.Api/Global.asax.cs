namespace Apexnet.Dispatch.Api
{
    using System.Web;
    using System.Web.Http;
    using Common.WebApi;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            DefaultWebApiConfig.Register("dispatch", "0.1.0", GlobalConfiguration.Configuration);
        }
    }
}