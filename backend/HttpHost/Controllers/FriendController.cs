using HttpHost.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HttpHost.Domain.Interfaces.Services;
using HttpHost.Domain.Dto.Headers;
using HttpHost.Domain.Dtos;

namespace HttpHost.Services.Controllers
{
    [ApiController]
    [Route("/friend")]
    public class FriendController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService, IUserService userService)
        {
            _userService = userService;
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
        [Route("/friend/{userId}")]
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

        [HttpGet]
        [Authorize]
        [Route("/friend/notifications/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetFriendsNotificationByUserId(string userId)
        {
            var friendsRequest = await _friendService.GetFriendsNotificationByUserId(userId);
            if (friendsRequest != null)
            {

                return Ok(friendsRequest);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        [Route("/friend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RequestFriend([FromHeader] AuthHeaderDto headerDto, Domain.Dtos.CreateFriendRequestDto friendRequest)
        {
            var currentUser = await _userService.GetUserIdentity(headerDto);
            var newFriend = await _friendService.CreateRequestFriend(currentUser.Id, friendRequest.Username);
            return Ok(newFriend);
        }

        [HttpPut]
        [Authorize]
        [Route("/friend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmFriend(Domain.Dto.FriendRequestDto friend)
        {
            var foundFriendRequisition = await _friendService.ConfirmFriendRequest(friend);
            return Ok(foundFriendRequisition);
        }
    }
}
