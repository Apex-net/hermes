namespace Messaging.Tests
{
    using System;
    using System.IO;
    using Apexnet.Messaging.Mail;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            var @from = new MailAddress("agesvil@wedoit.io", "AgendaBocconi (Sviluppo)");
            var to = new MailAddress("f.vassura@wedoit.io", "fabio vassura");

            string subject = "mail di test senza hermes (net.mail)";
            const string body =
                "<h1>prova mail</h1>" +
                "<p>mail senza \" attachments</p>";

            var mailMessage = new MailMessage(@from, to, subject, body, true);

            new MailMessageSender().Send(mailMessage);
        }
    }
}
