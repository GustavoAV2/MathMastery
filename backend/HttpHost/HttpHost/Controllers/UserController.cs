using System.Diagnostics;
using HttpHost.Data;
using HttpHost.Models;
using HttpHost.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomationsAPI.HttpHost.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserDb _userDb;

        public UserController(ILogger<UserController> logger, UserDb userDb)
        {
            _logger = logger;
            _userDb = userDb;
        }

        [HttpGet]
        [Route("/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Home()
        {
            return Ok("Api em funcionamento!");
        }

        [HttpGet]
        [Route("/user")]
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

        [HttpGet]
        [Route("/user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserById([FromRoute] string id, int page = 0)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var sw = Stopwatch.StartNew();

            User user = await _userDb.All.FindAsync(id);
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
        public async Task<IActionResult> PostUser(UserDto user)
        {
            var newUser = new User(
                    firstName : user.FirstName, lastName : user.LastName
                );
            _userDb.All.Add(newUser);
            await _userDb.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPut]
        [Route("/user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUser(int id, UserDto inputUser)
        {
            var user = await _userDb.All.FindAsync(id);

            if (user is null) return NotFound();

            user.FirstName = inputUser.FirstName;
            user.LastName = inputUser.LastName;

            await _userDb.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete]
        [Route("/user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUser(int id)
        {
            if (await _userDb.All.FindAsync(id) is User user)
            {
                _userDb.All.Remove(user);
                await _userDb.SaveChangesAsync();

                return Ok(user);
            }
            return NotFound();
        }
    }
}
