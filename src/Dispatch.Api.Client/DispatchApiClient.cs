namespace Apexnet.Dispatch.Api
{
    using System;
    using System.Threading.Tasks;
    using Apexnet.Dispatch.Api.Client.Configuration;
    using Common.Data_Access.Services;
    using Common.Data_Transfer;
    using Common.Protocols;

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

        public Task<ScheduledResponse> Schedule(ScheduledBundleRequest scheduledBundleRequest)
        {
            return this.httpService.CreateAsync<ScheduledBundleRequest, ScheduledResponse>(
                "api/schedule",
                scheduledBundleRequest,
                null);
        }

        public Task<bool> Cancel(Guid id)
        {
            return this.httpService.DeleteAsync(string.Format("jobs/{0}", id));
        }
    }
}