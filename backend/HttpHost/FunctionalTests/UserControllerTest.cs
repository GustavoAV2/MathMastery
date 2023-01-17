using FunctionalTests.Factories;
using HttpHost.Dto;
using System.Text.Json.Nodes;
using System.Text;

namespace FunctionalTests
{
    public class UserControllerTest
    {
        private HttpClient _httpClient { get; set; }

        public UserControllerTest() {
            _httpClient = HttpClientFactory.CreateClient();
            //_httpClient.DefaultRequestHeaders.Add("User-Agent", "C# program");
        }

        [Fact]
        public async void Test_CreateUser_Should_CreateUserAndReturnIt()
        {
            var userDto = new UserDto()
            {
                Email = "test",
                Password = "test",
                UserName = "test",
                FirstName = "test",
                LastName = "test",
                NumberResolvedAccounts = 0,
                NumberUnresolvedAccounts = 0
            };

            var content = new StringContent(userDto.ToString(), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestUri: "/user", content: content);

            Assert.Equal(response.StatusCode.ToString(), "201");
        }
    }
}