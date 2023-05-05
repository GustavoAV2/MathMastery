using HttpHost.Domain.Interfaces.Services;
using HttpHost.Services;
using HttpHost.Tests.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace HttpHost.Tests.Services
{
    public class EmailServiceTests
    {
        private readonly IEmailService emailService;
        private readonly Mock<ILogger<EmailService>> loggerMock;
        private readonly IConfiguration configuration;

        public EmailServiceTests()
        {
            loggerMock = new Mock<ILogger<EmailService>>();
            configuration = ConfigurationFactory.NewIConfiguration();
            emailService = new EmailService(loggerMock.Object, configuration);
        }

        [Fact]
        public void sendEmailTest()
        {
            var sent = emailService.SendEmail("gustavoant.voltolini@gmail.com", "Test Email", "Test Email");
            Assert.True(sent);
        }
    }
}
