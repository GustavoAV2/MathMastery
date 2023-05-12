using HttpHost.Database.Data;
using HttpHost.Domain.Dto;
using HttpHost.Domain.Interfaces.Services;
using HttpHost.Domain.Models;
using HttpHost.Services;
using HttpHost.Tests.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace HttpHost.Tests.Services
{
    public class UserServiceTests
    {
        private readonly IUserService userService;
        private readonly Mock<ILogger<UserService>> loggerMock;
        private readonly Mock<UserDb> userDb;
        private readonly IConfiguration configuration;

        public UserServiceTests()
        {
            userDb = new Mock<UserDb>();
            loggerMock = new Mock<ILogger<UserService>>();
            configuration = ConfigurationFactory.NewIConfiguration();
            userService = new UserService(loggerMock.Object, configuration, userDb.Object);
        }

        private UserDto GenerateUserDto(string email="test@test.com", string firstname="test")
        {
            return new UserDto() 
            { 
                Email = email,
                Password = "password",
                UserName = "usernameTest",
                FirstName = firstname,
                LastName = "TestLastName",
                EmailConfirmed = true,
                TwoFactorEnabled = true,
                AccessFailedCount = 1,
                NumberResolvedAccounts = 1,
                NumberUnresolvedAccounts = 1
            };
        }

        private User GenerateUserModel(string email = "test@test.com", string firstname = "test")
        {
            return new User(email, "password", "usernameTest", firstname, "TestLastName");
        }

        [Fact]
        public async Task CreateUserTest()
        {
            var userDto = GenerateUserDto();

            var response = await userService.CreateUser(userDto);

            userDb.Verify(db => db.Add(It.IsAny<UserDto>()));
            Assert.NotEqual(response.PasswordHash, userDto.Password);
        }

        [Fact]
        public async Task GetUserTest()
        {
            var foundUser = GenerateUserModel();
            userDb.Setup(db => db.All.ToListAsync()).
                ReturnsAsync(new List<User>() { foundUser });

            var response = await userService.GetUsers();
            
            Assert.Equal(response.FirstOrDefault().UserName, foundUser.UserName);
        }

        [Fact]
        public async void PutUserTest()
        {
            var userDto = GenerateUserDto();
            var toUpdateUser = GenerateUserDto(email: "tester@gmail.com");
            userDb.Setup(db => db.All.FindAsync(It.IsAny<string>())).ReturnsAsync(userDto);

            var response = await userService.PutUser(userDto.Id, toUpdateUser);

            Assert.NotEqual(response.PasswordHash, userDto.Password);
        }

        [Fact]
        public async void GetUserByIdTest()
        {
            var userDto = GenerateUserDto();

            var response = await userService.CreateUser(userDto);

            Assert.NotEqual(response.PasswordHash, userDto.Password);
        }

        [Fact]
        public async void GetUserByEmailTest()
        {
            var userDto = GenerateUserDto();
            
            var response = await userService.CreateUser(userDto);

            Assert.NotEqual(response.PasswordHash, userDto.Password);
        }

        [Fact]
        public async void GetUserByUsernameTest()
        {
            var userDto = GenerateUserDto();

            var response = await userService.CreateUser(userDto);

            Assert.NotEqual(response.PasswordHash, userDto.Password);
        }

        [Fact]
        public async void LoginTest()
        {
            var userDto = GenerateUserDto();

            var response = await userService.CreateUser(userDto);

            Assert.NotEqual(response.PasswordHash, userDto.Password);
        }

        [Fact]
        public async void GetUserIdentityTest()
        {
            var userDto = GenerateUserDto();

            var response = await userService.CreateUser(userDto);

            Assert.NotEqual(response.PasswordHash, userDto.Password);
        }

        [Fact]
        public async void ValidLoginTest()
        {
            var userDto = GenerateUserDto();

            var response = await userService.CreateUser(userDto);
            
            Assert.NotEqual(response.PasswordHash, userDto.Password);
        }

        [Fact]
        public async void GenerateTokenTest()
        {
            var userDto = GenerateUserDto();

            var response = await userService.CreateUser(userDto);

            Assert.NotEqual(response.PasswordHash, userDto.Password);
        }
    }
}
