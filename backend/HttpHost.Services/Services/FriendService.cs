using HttpHost.Database.Data;
using HttpHost.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<Users>> GetFriendsByUserId(string userId)
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
    }
}
