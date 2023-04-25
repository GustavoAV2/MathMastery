
using HttpHost.Domain.Dto;
using HttpHost.Domain.Dto.Headers;
using HttpHost.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpHost.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Users> DeleteUser(string userId);
        Task<Users> CreateUser(UserDto inputUser);
        Task<Users> PutUser(string userId, UserDto inputUser);
        Task<List<Users>> GetUsers();
        Task<Users> GetUserById(string userId);
        Task<Users> GetUserByEmail(string userEmail);
        Task<Users> GetUserByUsername(string userName);
        Task<string> Login(LoginUserDto loginDto);
        Task<Users> GetUserIdentity(AuthHeaderDto headerDto);
    }
}
