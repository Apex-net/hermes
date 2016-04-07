namespace Dispatch.Api.Client.Tests
{
    using System;
    using Apexnet.Dispatch.Api;
    using Apexnet.Messaging.Http;
    using Apexnet.Messaging.Mail;
    using Apexnet.Messaging.Push;
    using Dispatch.Api.Client.Tests.Annotations;
    using Xunit;

    [UsedImplicitly]
    public class UnitTest1
    {
        private readonly DispatchApiClient client = new DispatchApiClient();

        [Fact]
        [UsedImplicitly]
        public async void Test_Schedule()
        {
            var schedule = new DateTimeOffset(DateTime.Now);

            var request = new ScheduledBundleRequest(schedule);

            request.MailMessages.Add(NewMailMessage());
            request.HttpRequests.Add(NewHttpRequestMessage());
            request.ApexnetPushNotifications.Add(NewApexnetPushNotification());

            var response = await this.client.ScheduleAsync(request)
                                     .ConfigureAwait(false);

            Assert.NotNull(response.Id);
            Assert.Equal(schedule, response.Schedule);
        }

        [Fact]
        [UsedImplicitly]
        public async void Test_Recur()
        {
            const string EveryMinute = "*/1 * * * *";

            var request = new RecurringBundleRequest(EveryMinute);

            request.MailMessages.Add(NewMailMessage());
            request.HttpRequests.Add(NewHttpRequestMessage());
            request.ApexnetPushNotifications.Add(NewApexnetPushNotification());

            var response = await this.client.RecurAsync(request)
                                     .ConfigureAwait(false);

            Assert.NotNull(response.Id);
        }

        [Fact]
        [UsedImplicitly]
        public async void Test_Delete()
        {
            var id = Guid.Parse("025a3a20-3514-42a5-ac66-f01084539d87");

            var result = await this.client.CancelAsync(id)
                                   .ConfigureAwait(false);

            Assert.True(result);
        }

        #region /// internal ///////////////////////////////////////////////////

        private static MailMessage NewMailMessage()
        {
            const string Subject = "Hermes: test";
            const string Body =
                "<h1>Titolo</h1>" +
                "<p>Questa è una prova di <a href=\"https://github.com/Apex-net/hermes\">Hermes</a>.</p>" +
                "<p>Ignorare, grazie.</p>";
            const bool IsBodyHtml = true;

            return new MailMessage(AddressBook.Ali, AddressBook.AgendaSviluppo, Subject, Body, IsBodyHtml);
        }

        private static HttpRequestMessage NewHttpRequestMessage()
        {
            return new HttpRequestMessage("HEAD", "http://requestb.in/188o2xj1");
        }

        private static ApexnetPushNotification NewApexnetPushNotification()
        {
            const string AuthKey = "3892DB2C-53A9-4B57-9638-08C1E91319C8";
            const string AppKey = "IB";
            const string UserName = "admin";
            const string Message = "Ciao";

            return new ApexnetPushNotification(AuthKey, AppKey, UserName, Message);
        }

        #endregion
    }
}