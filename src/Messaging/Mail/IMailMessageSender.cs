namespace Apexnet.Messaging.Mail
{
    public interface IMailMessageSender
    {
        void Send(MailMessage message);
    }
}