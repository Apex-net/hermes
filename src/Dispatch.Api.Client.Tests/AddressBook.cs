namespace Dispatch.Api.Client.Tests
{
    using Apexnet.Messaging.Mail;

    public static class AddressBook
    {
        public static readonly MailAddress Ali = new MailAddress
        {
            Address = "a.donmez@apexnet.it",
            DisplayName = "Ali Servet Donmez"
        };

        public static readonly MailAddress Stefano = new MailAddress
        {
            Address = "s.teodorani@apexnet.it",
            DisplayName = "Stefano Teodorani"
        };

        public static readonly MailAddress Andrea = new MailAddress
        {
            Address = "a.caliesi@apexnet.it",
            DisplayName = "Andrea Calisesi"
        };

        public static readonly MailAddress Fabio = new MailAddress
        {
            Address = "f.vassura@apexnet.it",
            DisplayName = "Fabio Vassura"
        };
    }
}