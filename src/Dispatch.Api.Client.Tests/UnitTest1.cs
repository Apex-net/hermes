namespace Dispatch.Api.Client.Tests
{
    using System;
    using Apexnet.Dispatch.Api;
    using Apexnet.Messaging.Mail;
    using Apexnet.Messaging.Push;
    using Xunit;

    public class UnitTest1 : UnitTest1Base
    {
        private readonly DispatchApiClient client = new DispatchApiClient();

        [Fact]
        public async void TestMethod1()
        {
            var schedule = new DateTimeOffset(DateTime.Now);

            var bundle = new ScheduledBundle { Schedule = schedule };

            bundle.MailMessages.Add(NewMailMessage());
            bundle.ApexnetPushNotifications.Add(CreateNotification());

            var scheduled = await this.client.Send(bundle)
                                      .ConfigureAwait(false);

            Assert.NotNull(scheduled.Id);
            Assert.Equal(schedule, scheduled.Schedule);
        }

        #region /// internal ///////////////////////////////////////////////////

        private static ApexnetPushNotification CreateNotification()
        {
            return new ApexnetPushNotification
            {
                AuthKey = "3892DB2C-53A9-4B57-9638-08C1E91319C8",
                AppKey = "IB",
                UserName = "admin",
                Message = "Ciao"
            };
        }

        private static MailMessage NewMailMessage()
        {
            var mailMessage = new MailMessage { From = Ali };
            mailMessage.To.Add(Fabio);
            mailMessage.Cc.Add(Stefano);
            mailMessage.Cc.Add(Andrea);
            mailMessage.Bcc.Add(Ali);
            mailMessage.Subject = "Ciao mondo";
            mailMessage.Body = "<h1>Titolo</h1>";
            mailMessage.IsBodyHtml = true;
            return mailMessage;
        }

        #endregion
    }
}