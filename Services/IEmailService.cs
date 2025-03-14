using CarAPI.Models;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task UserSendEmailAsync(ContactMe contactMe);
    }
}
