namespace Apexnet.Messaging.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public class HttpRequestSender : IDisposable
    {
        private static readonly Dictionary<string, HttpMethod> HttpMethodsMapping = new Dictionary<string, HttpMethod>
        {
            { "DELETE", HttpMethod.Delete },
            { "GET", HttpMethod.Get },
            { "HEAD", HttpMethod.Head },
            { "OPTIONS", HttpMethod.Options },
            { "POST", HttpMethod.Post },
            { "PUT", HttpMethod.Put },
            { "TRACE", HttpMethod.Trace },
        };

        private readonly HttpClient httpClient;

        #region TODO: replace with IoC container

        public HttpRequestSender()
            : this(null) { }

        #endregion

        private HttpRequestSender(HttpClient smtpClient)
        {
            this.httpClient = smtpClient ?? new HttpClient();
        }

        public void Send(HttpRequestMessage message)
        {
            var httpRequestMessage = new System.Net.Http.HttpRequestMessage(
                HttpMethodsMapping[message.Method.ToUpperInvariant()],
                message.RequestUri);

            this.httpClient.SendAsync(httpRequestMessage)
                .Wait();
        }

        public void Dispose()
        {
            ((IDisposable)this.httpClient).Dispose();
        }
    }
}
