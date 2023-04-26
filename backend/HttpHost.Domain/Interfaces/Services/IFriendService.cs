
using HttpHost.Domain.Dto;
using HttpHost.Domain.Dtos;
using HttpHost.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpHost.Domain.Interfaces.Services
{
    public interface IFriendService
    {
        Task<List<Friends>> GetFriends();
        Task<List<Users>> GetUserFriendsByUserId(string userId);
        List<Friends> GetFriendsRequestByUserId(string userId);
        Task<Friends> CreateRequestFriend(string requesterId, string receiverUsername);
        Task<Friends> ConfirmFriendRequest(FriendDto friend);
    }
}
