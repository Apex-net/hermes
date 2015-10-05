namespace Apexnet.Dispatch.Api
{
    public class RecurringBundleRequest : BaseBundleRequest
    {
        public RecurringBundleRequest(string cronExpression)
        {
            this.CronExpression = cronExpression;
        }

        public string CronExpression { get; private set; }
    }
}