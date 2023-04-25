using HttpHost.Database.Data;
using HttpHost.Domain.Dto;
using HttpHost.Domain.Dto.Headers;
using HttpHost.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HttpHost.Services.Services
{
    public class UserService
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

        public async Task<List<Users>> GetUsers()
        {
            var sw = Stopwatch.StartNew();
            
            var users = await _userDb.All.ToListAsync();
            
            _logger.LogInformation($"Busca de usuários concluída em {sw.ElapsedMilliseconds} ms.");
            return users;
        }

        public async Task<Users> GetUserById(string userId)
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

        public async Task<Users> GetUserByEmail(string userEmail)
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

        public async Task<string> Login(LoginUserDto loginDto)
        {
            var foundUser = await GetUserByEmail(loginDto.Email);
            
            if (ValidLogin(foundUser, loginDto) == true)
            {
                var tokenJwt = GenerateToken(foundUser);
                return tokenJwt;
            }
            return "";
        }

        public async Task<Users> GetUserIdentity(AuthHeaderDto headerDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = headerDto.Authorization.Replace("Bearer ", "");
            var token = tokenHandler.ReadJwtToken(tokenString);
            var id = token.Payload["Id"];

            var foundUser = await _userDb.All.FindAsync(id);
            return foundUser;
        }

        private bool ValidLogin(Users foundUser, LoginUserDto loginDto)
        {
            if (foundUser.PasswordHash == loginDto.Password)
            {
                return true;
            }
            return false;
        }

        private string GenerateToken(Users foundUser)
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
