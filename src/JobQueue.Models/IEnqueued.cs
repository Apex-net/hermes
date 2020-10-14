namespace Apexnet.JobQueue
{
    using System;

    public interface IEnqueued
    {
        string Id { get; set; }
    }
}