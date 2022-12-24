using System.Diagnostics;
using HttpHost.Data;
using HttpHost.Models;
using HttpHost.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomationsAPI.HttpHost.Controllers
{
    [ApiController]
    [Route("/friend")]
    public class FriendController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly FriendDb _friendDb;

        public FriendController(ILogger<UserController> logger, FriendDb friendDb)
        {
            _logger = logger;
            _friendDb = friendDb;
        }

        [HttpGet]
        [Route("/friend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetFriends()
        {
            var sw = Stopwatch.StartNew();

            var friends = await _friendDb.All.ToListAsync();
            _logger.LogInformation("Time to search > {dur}", sw.ElapsedMilliseconds);

            if (!friends.Any())
                return NotFound();

            return Ok(friends);
        }

        [HttpGet]
        [Route("/friend/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserFriendsById([FromRoute] string id, int page = 0)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var sw = Stopwatch.StartNew();

            Friend? friend = await _friendDb.All.FindAsync(id);
            _logger.LogInformation("Get friend by id. Time to search >", sw.ElapsedMilliseconds);

            if (friend != null)
            {
                return Ok(friend);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("/friend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostFriend(FriendDto friend)
        {
            var newFriend = new Friend(
                   requesterId : friend.RequesterId, 
                   receiverId : friend.ReceiverId, 
                   status : friend.Status
                );
            _friendDb.All.Add(newFriend);
            await _friendDb.SaveChangesAsync();

            return Ok(newFriend);
        }

        [HttpPut]
        [Route("/friend/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmFriend(string id, string requesterId)
        {
            var friend = _friendDb.All.Where(f => f.RequesterId == requesterId).Single();

            if (friend is null) return NotFound();

            friend.ConfirmationDate = DateTime.Now;
            await _friendDb.SaveChangesAsync();

            return Ok(friend);
        }

        [HttpDelete]
        [Route("/friend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutUser(string id)
        {
            if (await _friendDb.All.FindAsync(id) is Friend friend)
            {
                _friendDb.All.Remove(friend);
                await _friendDb.SaveChangesAsync();
                return Ok(friend);
            }
            return NotFound();
        }
    }
}
