using HttpHost.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;

namespace HttpHost.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private IConfiguration _configuration { get; }

        public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public bool SendEmail(string recipientEmail, string subject, string body)
        {
            string senderEmail = _configuration["SenderEmail:Email"];
            string senderPassword = _configuration["SenderEmail:Password"];

            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderEmail);
            message.To.Add(new MailAddress(recipientEmail));
            message.Subject = subject;
            message.Body = body;

            SmtpClient smtpClient = new SmtpClient("smtp.exemplo.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            try
            {
                smtpClient.Send(message);
                _logger.LogInformation("E-mail enviado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Ocorreu um erro ao enviar o e-mail: " + ex.Message);
                return false;
            }
        }
    }
}
