using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using HttpHost.Domain.Dto;
using HttpHost.Domain.Models;
using HttpHost.Database.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HttpHost.Domain.Interfaces.Services;
using HttpHost.Domain.Dtos;

namespace HttpHost.Services
{
    public class FriendService : IFriendService
    {
        private readonly ILogger<FriendService> _logger;
        private readonly FriendRequestDb _friendDb;
        private readonly IUserService _userService;

        public FriendService(ILogger<FriendService> logger, IUserService userService, FriendRequestDb friendDb)
        {
            _logger = logger;
            _friendDb = friendDb;
            _userService = userService;
        }

        public async Task<List<FriendRequest>> GetFriends()
        {
            var sw = Stopwatch.StartNew();
            var friends = await _friendDb.All.ToListAsync();
            _logger.LogInformation("Time to search > {dur}", sw.ElapsedMilliseconds);

            return friends;
        }

        public async Task<List<FriendNotification>> GetFriendsNotificationByUserId(string userId)
        {
            var foundFriendsRequisition = _friendDb.Friend.
                Where(f => f.ReceiverId == userId && f.ConfirmationDate == null).ToList();

            var notifications = new List<FriendNotification>();
            foreach (var friendRequest in foundFriendsRequisition)
            {
                var user = await _userService.GetUserById(friendRequest.RequesterId);
                notifications.Add(
                    new FriendNotification()
                    {
                        Id = friendRequest.Id,
                        Username = user.UserName,
                        Status = friendRequest.Status
                    }
                );
            }
            return notifications;
        }
        public async Task<List<User>> GetUserFriendsByUserId(string userId)
        {
            var foundFriendsRequisition = _friendDb.Friend.
                Where(f => f.Status == FriendRequestStatus.Approved && f.ReceiverId == userId || f.RequesterId == userId).ToArray();

            List<User> friends = new List<User>();
            if (foundFriendsRequisition.Any())
            {
                foreach (var f in foundFriendsRequisition)
                {
                    var friendId = f.ReceiverId;
                    if (f.ReceiverId == userId)
                    {
                        friendId = f.RequesterId;
                    }
                    User user = await _userService.GetUserById(friendId);
                    friends.Add(user);
                }
            }
            return friends;
        }

        public async Task<FriendRequest> CreateRequestFriend(string requesterId, string receiverUsername)
        {
            if (await requestAlreadyExists(requesterId) == false)
            {
                var user = _userService.GetUserByUsername(receiverUsername);
                var newFriend = new FriendRequest(
                       requesterId: requesterId,
                       receiverId: user.Id,
                       status: FriendRequestStatus.Waiting
                    );
                _friendDb.All.Add(newFriend);
                await _friendDb.SaveChangesAsync();

                return newFriend;
            }
            throw new InvalidOperationException();
        }

        public async Task<FriendRequest> ReplyFriendRequest(string friendRequestId, FriendRequestStatus newStatus)
        {
            var foundFriendRequisition = await _friendDb.All.FirstOrDefaultAsync(f => f.Id == friendRequestId);

            if (foundFriendRequisition is null) throw new KeyNotFoundException("Nenhuma requisição de amizade de ID {friendRequestId} encontrada.\"");

            if (newStatus == FriendRequestStatus.Approved)
            {
                foundFriendRequisition.Status = FriendRequestStatus.Approved;
                foundFriendRequisition.ConfirmationDate = DateTime.Now;
                await _friendDb.SaveChangesAsync();
            }
            else
            {
                foundFriendRequisition.Status = FriendRequestStatus.Decline;
                await _friendDb.SaveChangesAsync();
            }
            return foundFriendRequisition;
        }

        private async Task<bool> requestAlreadyExists(string requesterId)
        {
            var friendNotification = await GetFriendsNotificationByUserId(requesterId);
            if (friendNotification.Any())
            {
                return true;
            }
            return false;
        }

}
}
