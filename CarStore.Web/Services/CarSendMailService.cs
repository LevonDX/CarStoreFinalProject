
using System.Net.Mail;

namespace CarStore.Web.Services
{
    public class CarSendMailService : ICarSendMailService
    {
        public async Task SendMailAsync(string to, string subject, string body)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mailMessage = new MailMessage();

            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            mailMessage.To.Add(to);
            mailMessage.From = new MailAddress("clevon85@outlook.com");

            mailMessage.Subject = subject;

            mailMessage.Body = body;
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
