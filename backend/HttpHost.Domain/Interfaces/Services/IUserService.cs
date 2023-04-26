
using HttpHost.Domain.Dto;
using HttpHost.Domain.Dto.Headers;
using HttpHost.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpHost.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> DeleteUser(string userId);
        Task<User> CreateUser(UserDto inputUser);
        Task<User> PutUser(string userId, UserDto inputUser);
        Task<List<User>> GetUsers();
        Task<User> GetUserById(string userId);
        User GetUserByEmail(string userEmail);
        User GetUserByUsername(string userName);
        string Login(LoginUserDto loginDto);
        Task<User> GetUserIdentity(AuthHeaderDto headerDto);
    }
}
