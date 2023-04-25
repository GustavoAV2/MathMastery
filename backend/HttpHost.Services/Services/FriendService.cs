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

namespace HttpHost.Services.Services
{
    public class FriendService
    {
        private readonly ILogger<FriendService> _logger;
        private readonly FriendDb _friendDb;
        private readonly UserService _userService;

        public FriendService(ILogger<FriendService> logger, UserService userService, FriendDb friendDb)
        {
            _logger = logger;
            _friendDb = friendDb;
            _userService = userService;
        }

        public async Task<List<Friends>> GetFriends()
        {
            var sw = Stopwatch.StartNew();
            var friends = await _friendDb.All.ToListAsync();
            _logger.LogInformation("Time to search > {dur}", sw.ElapsedMilliseconds);

            return friends;
        }

        public async Task<List<Users>> GetUserFriendsByUserId(string userId)
        {
            var foundFriendsRequisition = _friendDb.Friend.
                Where(f => f.ReceiverId == userId && f.ConfirmationDate != null).ToArray();
            
            List<Users> friends = new List<Users>();
            if (!foundFriendsRequisition.Any())
            {
                foreach (var f in foundFriendsRequisition)
                {
                    Users user = await _userService.GetUserById(f.RequesterId);
                    friends.Add(user);
                }
            }
            return friends;
        }

        public async Task<Friends> CreateRequestFriend(FriendDto friend)
        {
            var newFriend = new Friends(
                   requesterId: friend.RequesterId,
                   receiverId: friend.ReceiverId,
                   status: friend.Status
                );
            _friendDb.All.Add(newFriend);
            await _friendDb.SaveChangesAsync();

            return newFriend;
        }

        public async Task<Friends> ConfirmFriendRequest(FriendDto friend)
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
