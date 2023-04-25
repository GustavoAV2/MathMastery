
using HttpHost.Domain.Dto;
using HttpHost.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpHost.Domain.Interfaces.Services
{
    public interface IFriendService
    {
        Task<List<Friends>> GetFriends();
        Task<List<Users>> GetUserFriendsByUserId(string userId);
        Task<Friends> CreateRequestFriend(FriendDto friend);
        Task<Friends> ConfirmFriendRequest(FriendDto friend);
    }
}
