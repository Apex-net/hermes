namespace Apexnet.Dispatch.Api
{
    using System;

    public class ScheduledBundleRequest : BaseBundleRequest
    {
        public ScheduledBundleRequest(DateTimeOffset schedule)
        {
            this.Schedule = schedule;
        }

        public DateTimeOffset Schedule { get; private set; }
    }
}