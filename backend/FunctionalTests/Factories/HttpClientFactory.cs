using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace FunctionalTests.Factories
{
    class HttpClientFactory
    {
        public static HttpClient CreateClient()
        {
            var factory = new WebApplicationFactory<HttpHost.Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, configBuilder) =>
                {
                    configBuilder.AddInMemoryCollection();
                });
            });

            var httpClient = factory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer TestToken");
            return httpClient;
        }
    }
}
