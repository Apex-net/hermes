namespace Apexnet.Dispatch.Api
{
    using System.Threading.Tasks;
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
                               new RestHttpService(
                                   new DefaultHttpClient("http://localhost/Dispatch.Api/api/", "dispatch", "0.1.0"));
        }

        public Task<Scheduled> Send(ScheduledBundle scheduledBundle)
        {
            return this.httpService.CreateAsync<ScheduledBundle, Scheduled>("dispatch", scheduledBundle, null);
        }
    }
}