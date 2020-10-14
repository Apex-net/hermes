namespace Apexnet.Dispatch.Api
{
    using System;
    using Apexnet.Dispatch.Api.Annotations;
    using Apexnet.JobQueue;

    [UsedImplicitly]
    public class Enqueued : IEnqueued
    {
        public string Id { get; set; }
    }
}