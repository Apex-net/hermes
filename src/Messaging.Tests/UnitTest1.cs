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
            var to = new MailAddress("a.donmez@wedoit.io", "Ali Servet Donmez");

            var attachment1 = new Attachment(
                Convert.ToBase64String(File.ReadAllBytes(@"C:\Users\a.donmez\Desktop\prove firme foto\ddd.jpg")),
                "ddd.jpg",
                System.Net.Mime.MediaTypeNames.Image.Jpeg);
            var attachment2 = new Attachment(
                Convert.ToBase64String(File.ReadAllBytes(@"C:\Users\a.donmez\Desktop\prove firme foto\Admissions.pdf")),
                "Admissions.pdf",
                System.Net.Mime.MediaTypeNames.Application.Pdf);

            const string Body =
                "<h1>Test attachments</h1>" +
                "<p>I should have two attachments.</p>";

            var mailMessage = new MailMessage(@from, to, "Hello, World!", Body, true);
            mailMessage.Attachments.Add(attachment1);
            mailMessage.Attachments.Add(attachment2);

            new MailMessageSender().Send(mailMessage);
        }
    }
}
