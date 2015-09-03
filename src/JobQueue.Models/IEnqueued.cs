namespace Apexnet.JobQueue
{
    using System;

    public interface IEnqueued
    {
        Guid Id { get; set; }
    }
}