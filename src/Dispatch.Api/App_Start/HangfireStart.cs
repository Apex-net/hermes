﻿using Dispatch.Api.App_Start;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(HangfireStart))]

// ReSharper disable once CheckNamespace
namespace Dispatch.Api.App_Start
{
    using Hangfire;
    using Hangfire.MemoryStorage;
    using Owin;

    public class HangfireStart
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseMemoryStorage();

            // Map Dashboard to the `http://<your-app>/jobs` URL.
            app.UseHangfireDashboard("/jobs");

            app.UseHangfireServer();
        }
    }
}