using HttpHost.Domain.Dto;
using HttpHost.Domain.Dto.Headers;
using HttpHost.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HttpHost.Services.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
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
            try
            {
                var tokenJwt = _userService.Login(loginDto);
                if (!String.IsNullOrEmpty(tokenJwt)) {
                    return Ok(tokenJwt);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro no Login do usuário: {ErrorMessage}", ex.Message);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("/user/me")]
        [Authorize]
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
        [Route("/user/{id}")]
        [Authorize]
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
        [Route("/user/friend/{userEmail}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string userEmail)
        {
            if (string.IsNullOrWhiteSpace(userEmail))
                return BadRequest();

            try
            {
                var foundUser = _userService.GetUserByEmail(userEmail);
                return Ok(foundUser);
            }
            catch (Exception _)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/user/friend/{username}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserByUsername([FromRoute] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest();
            try
            {
                var foundUser = _userService.GetUserByUsername(username);
                return Ok(foundUser);
            }
            catch(Exception _)
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
            var newUser = await _userService.CreateUser(inputUser);
            return Ok(newUser);
        }

        [HttpPost]
        [Route("/user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InitializeUser(UserDto inputUser)
        {
            var newUser = await _userService.CreateUser(inputUser);
            return Ok(newUser);
        }

        [HttpPut]
        [Route("/user/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUser(string id, UserDto inputUser)
        {
            var foundUser = await _userService.PutUser(id, inputUser);
            return Ok(foundUser);
        }

        [HttpDelete]
        [Route("/user")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await _userService.DeleteUser(id);
                return Ok(user);
            }
            catch (Exception _)
            {
                return NotFound();
            }
        }
    }
}
