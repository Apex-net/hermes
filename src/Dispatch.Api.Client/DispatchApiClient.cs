namespace Apexnet.Dispatch.Api
{
    using System;
    using System.Threading.Tasks;
    using Client.Configuration;
    using NextCommon.Http.Data_Access.Services;
    using NextCommon.Http.Data_Transfer;
    using NextCommon.Http.Protocols;

    public class DispatchApiClient
    {
        private readonly IRestHttpClientAsync httpService;

        public DispatchApiClient()
            : this((IRestHttpClientAsync)null)
        {
        }

        public DispatchApiClient(string dispatchApiUrl)
            : this(CreateHttpService(dispatchApiUrl))
        {
        }

        private DispatchApiClient(IRestHttpClientAsync httpService)
        {
            this.httpService = httpService ?? CreateHttpService(DispatchApi.Instance.Url);
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

        #region /// internal ///////////////////////////////////////////////////

        private static RestHttpService CreateHttpService(string baseUri)
        {
            return new RestHttpService(new DefaultHttpClient(baseUri, "dispatch", "1"));
        }

        #endregion
    }
}