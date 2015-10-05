namespace Apexnet.Dispatch.Jobs
{
    using System;
    using System.Linq.Expressions;
    using Apexnet.JobQueue;
    using Apexnet.Messaging.Http;

    public class HttpRequestJob : IQueueable
    {
        private readonly HttpRequestMessage httpRequestMessage;

        public HttpRequestJob(HttpRequestMessage httpRequestMessage)
        {
            this.httpRequestMessage = httpRequestMessage;
        }

        public Expression<Action> Operation
        {
            get
            {
                return () => _Run(this.httpRequestMessage);
            }
        }

        //// ReSharper disable MemberCanBePrivate.Global
        public static void _Run(HttpRequestMessage request)
        {
            var sender = new HttpRequestSender();
            sender.Send(request);
        }

        //// ReSharper restore MemberCanBePrivate.Global
    }
}