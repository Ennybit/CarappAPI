using CarAPI.Models;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using WebApi.Models;

namespace WebApi.Services
{
    public class EmailService: IEmailService
    {
        private readonly EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = mailRequest.Body };
            


            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }

        public async Task UserSendEmailAsync(ContactMe contactMe)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(contactMe.Name, contactMe.Email));
            email.To.Add(new MailboxAddress("Admin", emailSettings.Email));
            email.ReplyTo.Add(new MailboxAddress(contactMe.Name, contactMe.Email));
            email.Subject = contactMe.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = contactMe.Body };



            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
