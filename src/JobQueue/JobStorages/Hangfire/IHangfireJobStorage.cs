namespace Apexnet.JobQueue.JobStorages.Hangfire
{
    using global::Hangfire;

    public interface IHangfireJobStorage
    {
        string Name { get; }

        void Configure(IGlobalConfiguration hangfireGlobalConfiguration);
    }
}