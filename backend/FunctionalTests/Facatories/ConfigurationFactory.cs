using Microsoft.Extensions.Configuration;

namespace HttpHost.Tests.Factories
{
    public static class ConfigurationFactory
    {
        public static IConfiguration NewIConfiguration()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                {"SenderEmail:Email", "" },
                {"SenderEmail:Password", "" },
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
        }
    }
}