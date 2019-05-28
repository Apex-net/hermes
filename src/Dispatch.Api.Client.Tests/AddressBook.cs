namespace Dispatch.Api.Client.Tests
{
    using Apexnet.Messaging.Mail;

    // ReSharper disable UnusedMember.Global
    public static class AddressBook
    {
        public static readonly MailAddress Stefano = new MailAddress("s.teodorani@wedoit.io", "Stefano Teodorani");

        public static readonly MailAddress Andrea = new MailAddress("a.bencini@wedoit.io", "Andrea Bencini");

        public static readonly MailAddress Fabio = new MailAddress("f.vassura@wedoit.io", "Fabio Vassura");

        public static readonly MailAddress AgendaSviluppo = new MailAddress("agesvil@wedoit.io", "AgendaBocconi (Sviluppo)");
    }
    // ReSharper restore UnusedMember.Global
}