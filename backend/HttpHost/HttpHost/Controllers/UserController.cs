using System.Diagnostics;
using HttpHost.Middlewares.Identification;
using HttpHost.Data;
using HttpHost.Models;
using HttpHost.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace HttpHost.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserDb _userDb;
        private IConfiguration _configuration { get; }

        public UserController(ILogger<UserController> logger, IConfiguration configuration, UserDb userDb)
        {
            _logger = logger;
            _userDb = userDb;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/user")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsers()
        {
            var sw = Stopwatch.StartNew();

            var users = await _userDb.All.ToListAsync();
            _logger.LogInformation("Time to search > {dur}", sw.ElapsedMilliseconds);

            if (!users.Any())
                return NotFound();

            return Ok(users);
        }

        [HttpPost]
        [Route("/user/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginUserDto loginDto)
        {
            var sw = Stopwatch.StartNew();

            var foundUser = _userDb.User.Where(user => user.Email == loginDto.Email).FirstOrDefault();
            _logger.LogInformation("Time to search > {dur}", sw.ElapsedMilliseconds);

            if (foundUser != null)
                if (foundUser.PasswordHash == loginDto.Password)
                {
                    var issuer = _configuration["Jwt:Issuer"];
                    var audience = _configuration["Jwt:Audience"];
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                            new Claim("Id", Guid.NewGuid().ToString()),
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
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var stringToken = tokenHandler.WriteToken(token);
                    return Ok(stringToken);
                }
            return Unauthorized();
        }

        [HttpGet]
        [Route("/user/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserById([FromRoute] string id, int page = 0)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var sw = Stopwatch.StartNew();

            Users user = await _userDb.All.FindAsync(id);
            _logger.LogInformation("Get user by id. Time to search >", sw.ElapsedMilliseconds);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("/user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(UserDto inputUser)
        {
            var newUser = new Users(
                    email : inputUser.Email, passwordHash : inputUser.Password, 
                    userName: inputUser.UserName, firstName : inputUser.FirstName, 
                    lastName : inputUser.LastName
                );
            _userDb.All.Add(newUser);
            await _userDb.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPut]
        [Authorize]
        [Route("/user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUser(int id, UserDto inputUser)
        {
            var foundUser = await _userDb.All.FindAsync(id);

            if (foundUser is null) return NotFound();

            foundUser.FirstName = inputUser.FirstName;
            foundUser.LastName = inputUser.LastName;
            foundUser.UserName = inputUser.UserName;
            foundUser.PasswordHash = inputUser.Password;

            await _userDb.SaveChangesAsync();

            return Ok(foundUser);
        }

        [HttpDelete]
        [Authorize]
        [Route("/user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (await _userDb.All.FindAsync(id) is Users user)
            {
                _userDb.All.Remove(user);
                await _userDb.SaveChangesAsync();

                return Ok(user);
            }
            return NotFound();
        }
    }
}
