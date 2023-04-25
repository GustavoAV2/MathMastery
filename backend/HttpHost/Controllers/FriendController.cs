using System.Diagnostics;
using HttpHost.Domain.Dto;
using HttpHost.Domain.Models;
using HttpHost.Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace HttpHost.Services.Controllers
{
    [ApiController]
    [Route("/friend")]
    public class FriendController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public FriendController(ILogger<UserController> logger)
        {
            _logger = logger;
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

        [HttpGet]
        [Authorize]
        [Route("/friend/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetFriendsByUserId(string userId)
        {
            var foundFriendsRequisition = _friendDb.Friend.
                Where(f => f.ReceiverId == userId && f.ConfirmationDate != null).ToArray();

            if (!foundFriendsRequisition.Any())
            {
                foreach (var f in foundFriendsRequisition)
                {
                    
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        [Route("/friend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RequestFriend(FriendDto friend)
        {
            var newFriend = new Friends(
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
        [Route("/friend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmFriend(FriendDto friend)
        {
            var foundFriendRequisition = _friendDb.Friend.
                Where(f => f.RequesterId == friend.RequesterId 
                && f.ReceiverId == friend.ReceiverId).FirstOrDefault();

            if (foundFriendRequisition is null) return NotFound();

            foundFriendRequisition.ConfirmationDate = DateTime.Now;
            await _friendDb.SaveChangesAsync();

            return Ok(foundFriendRequisition);
        }
    }
}
