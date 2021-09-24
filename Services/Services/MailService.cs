using Core.Models;
using Core.Settings;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Services.Services
{
    class MailService
    {
        private readonly MailSettings mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }
        public async Task SendEmail(MailRequest mailRequest) //SOR BUNU!!!!!
        {
            var email = new MailMessage();
            email.Sender = new MailAddress(mailSettings.Mail);
            email.From = new MailAddress(mailSettings.Mail);
            email.To.Add((MailAddress)MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.HtmlBody;

            NetworkCredential networkCredential = new NetworkCredential(mailSettings.Mail, mailSettings.Password);

            var smtp = new SmtpClient();
            smtp.Host = mailSettings.Host;
            smtp.Port = mailSettings.Port;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = networkCredential;
            smtp.Send(email);
            smtp.Dispose();
        }
    }
}
