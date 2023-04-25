using HttpHost.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HttpHost.Domain.Interfaces.Services;

namespace HttpHost.Services.Controllers
{
    [ApiController]
    [Route("/friend")]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet]
        [Authorize]
        [Route("/friend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetFriends()
        {
            var friends = await _friendService.GetFriends();
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
            var friends = await _friendService.GetUserFriendsByUserId(userId);
            if (friends != null)
            {
                return Ok(friends);
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
            var newFriend = await _friendService.CreateRequestFriend(friend);
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
            var foundFriendRequisition = await _friendService.ConfirmFriendRequest(friend);
            return Ok(foundFriendRequisition);
        }
    }
}
