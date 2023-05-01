using System;
using System.Linq;
using System.Text;
using System.Diagnostics;
using HttpHost.Database.Data;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using HttpHost.Domain.Dto;
using HttpHost.Domain.Dto.Headers;
using HttpHost.Domain.Models;
using HttpHost.Domain.Interfaces.Services;


namespace HttpHost.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly UserDb _userDb;
        private IConfiguration _configuration { get; }

        public UserService(ILogger<UserService> logger, IConfiguration configuration, UserDb userDb)
        {
            _logger = logger;
            _userDb = userDb;
            _configuration = configuration;
        }

        public async Task<User> DeleteUser(string userId)
        {
            if (await _userDb.All.FindAsync(userId) is User user)
            {
                _userDb.All.Remove(user);
                await _userDb.SaveChangesAsync();

                return user;
            }
            throw new KeyNotFoundException($"Usuário com ID {userId} não encontrado.");
        }


        public async Task<User> CreateUser(UserDto inputUser)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(inputUser.Password);

            var newUser = new User(
                email: inputUser.Email, passwordHash: passwordHash,
                userName: inputUser.UserName, firstName: inputUser.FirstName,
                lastName: inputUser.LastName
            );

            _userDb.All.Add(newUser);
            await _userDb.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> PutUser(string userId, UserDto inputUser)
        {
            var foundUser = await _userDb.All.FindAsync(userId);
            if (foundUser is null)
            {
                throw new KeyNotFoundException($"Usuário com ID {userId} não encontrado.");
            }

            foundUser.FirstName = inputUser.FirstName.IsNullOrEmpty() ? foundUser.FirstName : inputUser.FirstName;
            foundUser.LastName = inputUser.LastName.IsNullOrEmpty() ? foundUser.LastName : inputUser.LastName;
            foundUser.UserName = inputUser.UserName.IsNullOrEmpty() ? foundUser.UserName : inputUser.UserName;
            if (inputUser.NumberUnresolvedAccounts.HasValue && inputUser.NumberResolvedAccounts.HasValue)
            {
                foundUser.NumberUnresolvedAccounts = inputUser.NumberUnresolvedAccounts.Value;
                foundUser.NumberResolvedAccounts = inputUser.NumberResolvedAccounts.Value;
            }

            await _userDb.SaveChangesAsync();
            return foundUser;
        }

        public async Task<List<User>> GetUsers()
        {
            var sw = Stopwatch.StartNew();
            
            var users = await _userDb.All.ToListAsync();
            
            _logger.LogInformation($"Busca de usuários concluída em {sw.ElapsedMilliseconds} ms.");
            return users;
        }

        public async Task<User> GetUserById(string userId)
        {
            var sw = Stopwatch.StartNew();
            var user = await _userDb.All.FirstOrDefaultAsync(u => u.Id == userId);

            _logger.LogInformation($"Busca de usuário pelo ID concluída em {sw.ElapsedMilliseconds} ms.");
            if (user == null)
            {
                throw new KeyNotFoundException($"Usuário com ID {userId} não encontrado.");
            }
            return user;
        }

        public User GetUserByEmail(string userEmail)
        {
            var sw = Stopwatch.StartNew();
            var foundUser = _userDb.User.Where(user => user.Email == userEmail).FirstOrDefault();
            _logger.LogInformation($"Busca de usuário pelo e-mail concluída em {sw.ElapsedMilliseconds} ms.");

            if (foundUser == null)
            {
                throw new KeyNotFoundException();
            }
            return foundUser;
        }

        public User GetUserByUsername(string userName)
        {
            var sw = Stopwatch.StartNew();
            var foundUser = _userDb.User.Where(user => user.UserName == userName).FirstOrDefault();
            _logger.LogInformation($"Busca de usuário pelo username concluída em {sw.ElapsedMilliseconds} ms.");

            if (foundUser == null)
            {
                throw new KeyNotFoundException();
            }
            return foundUser;
        }

        public string Login(LoginUserDto loginDto)
        {
            var foundUser = GetUserByEmail(loginDto.Email);
            
            if (ValidLogin(loginDto.Password, foundUser.PasswordHash) == true)
            {
                var tokenJwt = GenerateToken(foundUser);
                return tokenJwt;
            }
            return "";
        }


        public async Task<User> GetUserIdentity(AuthHeaderDto headerDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = headerDto.Authorization.Replace("Bearer ", "");
            var token = tokenHandler.ReadJwtToken(tokenString);
            var id = token.Payload["Id"];

            var foundUser = await _userDb.All.FindAsync(id);
            return foundUser;
        }

        private bool ValidLogin(string Password, string PasswordHash)
        {
            return BCrypt.Net.BCrypt.Verify(Password, PasswordHash);
        }

        private string GenerateToken(User foundUser)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                            new Claim("Id", foundUser.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub, foundUser.UserName),
                            new Claim(JwtRegisteredClaimNames.Email, foundUser.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                        }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenJwt = tokenHandler.CreateEncodedJwt(tokenDescriptor);
            return tokenJwt;
        }
    }
}
