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
                    new FriendNotification() { 
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
                Where(f => f.ReceiverId == userId && f.ConfirmationDate != null).ToArray();
            
            List<User> friends = new List<User>();
            if (!foundFriendsRequisition.Any())
            {
                foreach (var f in foundFriendsRequisition)
                {
                    User user = await _userService.GetUserById(f.RequesterId);
                    friends.Add(user);
                }
            }
            return friends;
        }

        public async Task<FriendRequest> CreateRequestFriend(string requesterId, string receiverUsername)
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

        public async Task<FriendRequest> ConfirmFriendRequest(Domain.Dto.FriendRequestDto friend)
        {
            var foundFriendRequisition = _friendDb.Friend.
                Where(f => f.RequesterId == friend.RequesterId
                && f.ReceiverId == friend.ReceiverId).FirstOrDefault();

            if (foundFriendRequisition is null) throw new KeyNotFoundException("Nenhuma requisição de amizade de UserID {userId} encontrada.\"");

            foundFriendRequisition.ConfirmationDate = DateTime.Now;
            await _friendDb.SaveChangesAsync();

            return foundFriendRequisition;
        }
    }
}
