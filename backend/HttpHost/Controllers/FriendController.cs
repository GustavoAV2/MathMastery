using System.Diagnostics;
using HttpHost.Data;
using HttpHost.Models;
using HttpHost.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HttpHost.Middlewares.Identification;
using Microsoft.AspNetCore.Authorization;

namespace HttpHost.Controllers
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
        [Authorize]
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

        [HttpPost]
        [Authorize]
        [Route("/friend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RequestFriend(FriendDto friend)
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
        [Authorize]
        [Route("/friend/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmFriend(string receiverId, string requesterId)
        {
            var foundFriendRequisition = _friendDb.Friend.
                Where(f => f.RequesterId == requesterId && f.ReceiverId == receiverId).FirstOrDefault();

            if (foundFriendRequisition is null) return NotFound();

            foundFriendRequisition.ConfirmationDate = DateTime.Now;
            await _friendDb.SaveChangesAsync();

            return Ok(foundFriendRequisition);
        }
    }
}
