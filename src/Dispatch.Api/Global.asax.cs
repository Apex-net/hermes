namespace Apexnet.Dispatch.Api
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Apexnet.Dispatch.Api.App_Start;
    using Common.WebApi;
    using Elmah.Contrib.WebApi;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Filters.Add(new ElmahHandleErrorApiAttribute());

            GlobalConfiguration.Configure(WebApiConfig.Register);

            DefaultWebApiConfig.Register("dispatch", "1", GlobalConfiguration.Configuration);

            HangfireBootstrapper.Instance.Start();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            HangfireBootstrapper.Instance.Stop();
        }
    }
}