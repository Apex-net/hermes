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

        // ReSharper disable UnusedMember.Global
        public DispatchApiClient()
            : this(null)
        {
        }

        // ReSharper restore UnusedMember.Global
        ////
        #endregion

        private DispatchApiClient(IRestHttpClientAsync httpService)
        {
            this.httpService = httpService ??
                               new RestHttpService(new DefaultHttpClient(DispatchApi.Instance.Url, "dispatch", "0"));
        }

        public Task<Scheduled> Send(ScheduledBundle scheduledBundle)
        {
            return this.httpService.CreateAsync<ScheduledBundle, Scheduled>("dispatch", scheduledBundle, null);
        }

        public Task<bool> Cancel(Guid id)
        {
            return this.httpService.DeleteAsync(string.Format("messages/{0}", id));
        }
    }
}