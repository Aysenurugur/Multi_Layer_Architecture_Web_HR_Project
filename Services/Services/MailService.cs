using Core.Models;
using Core.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
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

        public void SendEmail(MailRequest mailRequest) //SOR BUNU!!!!!
        {
            //var email = new MimeMessage();
            //email.Sender = new MailAddress(mailSettings.Mail);
            //email.From = new MailAddress(mailSettings.Mail);
            //email.To.Add((MailAddress)MailboxAddress.Parse(mailRequest.ToEmail));
            //email.Subject = mailRequest.Subject;

            //BodyBuilder builder = new BodyBuilder();
            //builder.HtmlBody = mailRequest.Body;
            //email.Body = builder.HtmlBody;

            //NetworkCredential networkCredential = new NetworkCredential(mailSettings.Mail, mailSettings.Password);

            //var smtp = new SmtpClient();
            ////smtp.Host = mailSettings.Host;
            ////smtp.Port = mailSettings.Port;
            ////smtp.UseDefaultCredentials = false;
            ////smtp.EnableSsl = true;
            ////smtp.Credentials = networkCredential;
            //smtp.Send(email);
            //smtp.Dispose();
        }
    }
}


/*
 public class EmailService : IEmailService
    {
        public bool SendEmail(string email, int userId, UserTypeEnum userType)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Blog", "denemeblog55@gmail.com"));
            message.To.Add(MailboxAddress.Parse(email));

            switch (userType)
            {
                case UserTypeEnum.Register:
                    message.Subject = "Hesap Aktivasyonu";
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = "<p>Hesabınızı aktifleştirmek için <a href=" + "https://localhost:44354/User/RegisterConfirm/" + userId + ">buraya</a> tıklayın.</p>"
                    };
                    break;
                case UserTypeEnum.Login:
                    message.Subject = "Giriş Doğrulama";
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = "<p>Giriş yapmak için <a href=" + "https://localhost:44354/User/LoginConfirm/" + userId + ">buraya</a> tıklayın.</p>"
                    };
                    break;
            }

            string fromEmail = "denemeblog55@gmail.com";
            string fromPassword = "deneme123";

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate(fromEmail, fromPassword);
                smtpClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }
 
 */