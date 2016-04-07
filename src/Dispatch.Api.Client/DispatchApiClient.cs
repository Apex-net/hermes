namespace Apexnet.Dispatch.Api
{
    using System;
    using System.Threading.Tasks;
    using Apexnet.Dispatch.Api.Client.Configuration;
    using NextCommon.Http.Data_Access.Services;
    using NextCommon.Http.Data_Transfer;
    using NextCommon.Http.Protocols;

    public class DispatchApiClient
    {
        private readonly IRestHttpClientAsync httpService;

        #region TODO: replace with IoC container

        public DispatchApiClient()
            : this(null)
        {
        }

        #endregion

        private DispatchApiClient(IRestHttpClientAsync httpService)
        {
            this.httpService = httpService ??
                               new RestHttpService(new DefaultHttpClient(DispatchApi.Instance.Url, "dispatch", "1"));
        }

        public Task<ScheduledResponse> ScheduleAsync(ScheduledBundleRequest request)
        {
            return this.httpService.CreateAsync<ScheduledBundleRequest, ScheduledResponse>("schedule", request, null);
        }

        public Task<EnqueuedResponse> RecurAsync(RecurringBundleRequest request)
        {
            return this.httpService.CreateAsync<RecurringBundleRequest, EnqueuedResponse>("recur", request, null);
        }

        public Task<bool> CancelAsync(Guid id)
        {
            return this.httpService.DeleteAsync(string.Format("jobs/{0}", id));
        }
    }
}