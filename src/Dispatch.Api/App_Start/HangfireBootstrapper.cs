using Apexnet.Dispatch.Api.Properties;
using Apexnet.JobQueue.JobStorages.Hangfire;
using Hangfire;
using Hangfire.Logging;
using Hangfire.Logging.LogProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Apexnet.Dispatch.Api.App_Start
{
    public class HangfireBootstrapper : IRegisteredObject
    {
        public static readonly HangfireBootstrapper Instance = new HangfireBootstrapper();

        private readonly object _lockObject = new object();
        private bool _started;

        private BackgroundJobServer _backgroundJobServer;

        private static readonly IHangfireJobStorage[] HangfireJobStorages =
        {
            new HangfireRedisStorage("hangfire-redis"),
            new HangfireMemoryStorage("hangfire-memory"),
            new HangfireSqlServerStorage("hangfire-sqlserver")
        };

        private HangfireBootstrapper()
        {
        }

        public void Start()
        {
            lock (_lockObject)
            {
                if (_started) return;
                _started = true;

                HostingEnvironment.RegisterObject(this);

                ConfigureEnabledHangfireJobStorage(Settings.Default.JobStorageName);

                // Map Dashboard to the `http://<your-app>/jobs` URL.
                // app.UseHangfireDashboard("/jobs");
                // app.UseHangfireServer();

                //LogProvider.SetCurrentLogProvider(new ElmahLogProvider(LogLevel.Info));

                /*GlobalConfiguration.Configuration
                    .UseSqlServerStorage("connection string");*/
                // Specify other options here

                _backgroundJobServer = new BackgroundJobServer();
            }
        }

        public void Stop()
        {
            lock (_lockObject)
            {
                if (_backgroundJobServer != null)
                {
                    _backgroundJobServer.Dispose();
                }

                HostingEnvironment.UnregisterObject(this);
            }
        }

        void IRegisteredObject.Stop(bool immediate)
        {
            Stop();
        }

        private static void ConfigureEnabledHangfireJobStorage(string configuredStorageName)
        {
            HangfireJobStorages.Single(x => x.Name == configuredStorageName)
                               .Configure(GlobalConfiguration.Configuration);
        }
    }
}