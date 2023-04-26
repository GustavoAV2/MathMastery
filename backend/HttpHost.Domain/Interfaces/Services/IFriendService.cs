
using HttpHost.Domain.Dto;
using HttpHost.Domain.Dtos;
using HttpHost.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpHost.Domain.Interfaces.Services
{
    public interface IFriendService
    {
        Task<List<FriendRequest>> GetFriends();
        Task<List<User>> GetUserFriendsByUserId(string userId);
        Task<List<FriendNotification>> GetFriendsNotificationByUserId(string userId);
        Task<FriendRequest> CreateRequestFriend(string requesterId, string receiverUsername);
        Task<FriendRequest> ConfirmFriendRequest(Dto.FriendRequestDto friend);
    }
}
