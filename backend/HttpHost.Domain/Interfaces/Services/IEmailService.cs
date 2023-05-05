
namespace HttpHost.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        bool SendEmail(string recipientEmail, string subject, string body);
    }
}
