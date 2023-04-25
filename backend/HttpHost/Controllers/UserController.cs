using System.Text;
using HttpHost.Dto;
using HttpHost.Domain.Dto;
using System.Diagnostics;
using HttpHost.Database.Data;
using System.Security.Claims;
using HttpHost.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HttpHost.Domain.Dto.Headers;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System;
using HttpHost.Services.Services;

namespace HttpHost.Services.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;
        private IConfiguration _configuration { get; }

        public UserController(ILogger<UserController> logger, IConfiguration configuration, UserService userService)
        {
            _logger = logger;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet]
        [Route("/user")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
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
            var tokenJwt = await _userService.Login(loginDto);
            if (!String.IsNullOrEmpty(tokenJwt)) {
                return Ok(tokenJwt);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize]
        [Route("/user/me")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Identity([FromHeader] AuthHeaderDto headerDto)
        {
            if (headerDto.Authorization != null)
            {
                var foundUser = await _userService.GetUserIdentity(headerDto);
                return Ok(foundUser);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize]
        [Route("/user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserById([FromRoute] string id, int page = 0)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro na busca: {ErrorMessage}", ex.Message);
            }
            return NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("/user/friend/{usernameOrEmail}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserByUsernameOrEmail([FromRoute] string usernameOrEmail)
        {
            Users foundUser;

            if (string.IsNullOrWhiteSpace(usernameOrEmail))
                return BadRequest();

            if (usernameOrEmail.Contains("@"))
            {
                foundUser = _userDb.User.
                    Where(user => user.Email == usernameOrEmail).FirstOrDefault();
            }
            else
            {
                foundUser = _userDb.User.
                    Where(user => user.UserName == usernameOrEmail).FirstOrDefault();
            }

            if (foundUser != null)
            {
                return Ok(foundUser);
            }
            return NotFound();
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
        public async Task<IActionResult> PutUser(string id, UserDto inputUser)
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

        [HttpPut]
        [Authorize]
        [Route("/user/game/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutGameUserStatus(string id, UserGameStatusDto statusDto)
        {
            var foundUser = await _userDb.All.FindAsync(id);
            if (foundUser is null) return NotFound();

            foundUser.NumberUnresolvedAccounts = statusDto.NumberUnresolvedAccounts + foundUser.NumberUnresolvedAccounts;
            foundUser.NumberResolvedAccounts = statusDto.NumberResolvedAccounts + foundUser.NumberResolvedAccounts;

            await _userDb.SaveChangesAsync();
            return Ok();
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
