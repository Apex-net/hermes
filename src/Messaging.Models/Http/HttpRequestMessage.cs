namespace Apexnet.Messaging.Http
{
    public class HttpRequestMessage
    {
        public HttpRequestMessage(string method, string requestUri)
        {
            this.Method = method;
            this.RequestUri = requestUri;
        }

        public string Method { get; private set; }

        public string RequestUri { get; private set; }
    }
}
