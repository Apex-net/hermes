namespace Dispatch.Api.Client.Tests
{
    using System;
    using Apexnet.Dispatch.Api;
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
        public async void TestMethod1()
        {
            var schedule = new DateTimeOffset(DateTime.Now);

            var bundle = new ScheduledBundleRequest(schedule);

            bundle.MailMessages.Add(NewMailMessage());
            bundle.ApexnetPushNotifications.Add(CreateNotification());

            var scheduled = await this.client.Schedule(bundle)
                                      .ConfigureAwait(false);

            Assert.NotNull(scheduled.Id);
            Assert.Equal(schedule, scheduled.Schedule);
        }

        [Fact]
        [UsedImplicitly]
        public async void TestMethod2()
        {
            var id = Guid.Parse("025a3a20-3514-42a5-ac66-f01084539d87");

            var result = await this.client.Cancel(id)
                                   .ConfigureAwait(false);

            Assert.True(result);
        }

        #region /// internal ///////////////////////////////////////////////////

        private static ApexnetPushNotification CreateNotification()
        {
            const string AuthKey = "3892DB2C-53A9-4B57-9638-08C1E91319C8";
            const string AppKey = "IB";
            const string UserName = "admin";
            const string Message = "Ciao";

            return new ApexnetPushNotification(AuthKey, AppKey, UserName, Message);
        }

        private static MailMessage NewMailMessage()
        {
            const string Subject = "Ciao mondo";
            const string Body = "<h1>Titolo</h1>";
            const bool IsBodyHtml = true;

            return new MailMessage(AddressBook.Ali, AddressBook.Fabio, Subject, Body, IsBodyHtml);
        }

        #endregion
    }
}