using Core.Models;

namespace Core.Services
{
    public interface IMailService
    {
        void SendEmail(MailRequest mailRequest);
    }
}
