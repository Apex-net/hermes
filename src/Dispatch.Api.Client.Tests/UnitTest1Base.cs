namespace Dispatch.Api.Client.Tests
{
    using Apexnet.Messaging.Mail;

    public class UnitTest1Base
    {
        protected static readonly MailAddress Ali = new MailAddress
        {
            Address = "a.donmez@apexnet.it",
            DisplayName = "Ali Servet Donmez"
        };
        protected static readonly MailAddress Stefano = new MailAddress
        {
            Address = "s.teodorani@apexnet.it",
            DisplayName = "Stefano Teodorani"
        };
        protected static readonly MailAddress Andrea = new MailAddress
        {
            Address = "a.caliesi@apexnet.it",
            DisplayName = "Andrea Calisesi"
        };
        protected static readonly MailAddress Fabio = new MailAddress
        {
            Address = "f.vassura@apexnet.it",
            DisplayName = "Fabio Vassura"
        };
    }
}