using Apexnet.Dispatch.Api.App_Start;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(HangfireStart))]

// ReSharper disable once CheckNamespace
namespace Apexnet.Dispatch.Api.App_Start
{
    using System.Linq;
    using Apexnet.Dispatch.Api.Properties;
    using Apexnet.JobQueue.JobStorages.Hangfire;
    using Common.Annotations;
    using Hangfire;
    using Owin;

    public class HangfireStart
    {
        private static readonly IHangfireJobStorage[] HangfireJobStorages =
        {
            new HangfireRedisStorage("hangfire-redis"), 
            new HangfireMemoryStorage("hangfire-memory")
        };

        [UsedImplicitly]
        public void Configuration(IAppBuilder app)
        {
            ConfigureEnabledHangfireJobStorage(Settings.Default.JobStorageName);

            // Map Dashboard to the `http://<your-app>/jobs` URL.
            app.UseHangfireDashboard("/jobs");

            app.UseHangfireServer();
        }

        #region /// internal ///////////////////////////////////////////////////

        private static void ConfigureEnabledHangfireJobStorage(string configuredStorageName)
        {
            HangfireJobStorages.Single(x => x.Name == configuredStorageName)
                               .Configure(GlobalConfiguration.Configuration);
        }

        #endregion
    }
}