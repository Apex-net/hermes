namespace Apexnet.Dispatch.Api
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.JobQueue;
    using Newtonsoft.Json;

    public class Enqueued : IEnqueued
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [JsonIgnore]
        public Expression<Action> Job { get; private set; }
    }
}