namespace Apexnet.Dispatch.Api
{
    using System.Collections.Generic;
    using Apexnet.Messaging.Mail;
    using Apexnet.Messaging.Push;

    public interface IBundleRequest
    {
        // ReSharper disable once ReturnTypeCanBeEnumerable.Global
        ICollection<MailMessage> MailMessages { get; }

        // ReSharper disable once ReturnTypeCanBeEnumerable.Global
        ICollection<ApexnetPushNotification> ApexnetPushNotifications { get; }
    }
}