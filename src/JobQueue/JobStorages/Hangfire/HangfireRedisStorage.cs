namespace Apexnet.JobQueue.JobStorages.Hangfire
{
    using Common.Utils;
    using global::Hangfire;
    using global::Hangfire.Redis.StackExchange;

    public class HangfireRedisStorage : IHangfireJobStorage
    {
        public HangfireRedisStorage(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void Configure(IGlobalConfiguration hangfireGlobalConfiguration)
        {
            var configuration = global::Apexnet.JobQueue.Configuration.RedisStorage.Instance;

            var options = ConfigureHangfireRedisStorageOptions(configuration.RedisStorageOptions);
            hangfireGlobalConfiguration.UseRedisStorage(configuration.ConnectionString, options);
        }

        #region /// internal ///////////////////////////////////////////////////

        private static RedisStorageOptions ConfigureHangfireRedisStorageOptions(
            global::Apexnet.JobQueue.Configuration.RedisStorageOptions configuration)
        {
            var options = new RedisStorageOptions();

            configuration.Db.InvokeConditionally(value => options.Db = value);
            configuration.InvisibilityTimeout.InvokeConditionally(value => options.InvisibilityTimeout = value);
            configuration.Prefix.InvokeConditionally(
                s => !string.IsNullOrWhiteSpace(s),
                value => options.Prefix = value);

            return options;
        }

        #endregion
    }
}