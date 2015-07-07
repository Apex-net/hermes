namespace Apexnet.JobQueue.JobStorages.Hangfire
{
    using global::Hangfire;
    using global::Hangfire.MemoryStorage;

    public class HangfireMemoryStorage : IHangfireJobStorage
    {
        public HangfireMemoryStorage(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void Configure(IGlobalConfiguration hangfireGlobalConfiguration)
        {
            hangfireGlobalConfiguration.UseMemoryStorage();
        }
    }
}