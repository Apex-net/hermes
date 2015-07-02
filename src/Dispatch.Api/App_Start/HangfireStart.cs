using Apexnet.Dispatch.Api.App_Start;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(HangfireStart))]

// ReSharper disable once CheckNamespace
namespace Apexnet.Dispatch.Api.App_Start
{
    using System;
    using Common.Annotations;
    using Hangfire;
    using Hangfire.Redis.StackExchange;
    using Owin;

    public class HangfireStart
    {
        [UsedImplicitly]
        public void Configuration(IAppBuilder app)
        {
            ////GlobalConfiguration.Configuration.UseMemoryStorage();
            GlobalConfiguration.Configuration.UseRedisStorage(
                "tangeri:6379",
                new RedisStorageOptions { Prefix = "hangfire:" });

            // Map Dashboard to the `http://<your-app>/jobs` URL.
            app.UseHangfireDashboard("/jobs");

            app.UseHangfireServer(new BackgroundJobServerOptions { SchedulePollingInterval = TimeSpan.FromSeconds(5) });
        }
    }
}