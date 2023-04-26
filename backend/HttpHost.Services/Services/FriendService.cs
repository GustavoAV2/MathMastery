﻿using System;
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
        private readonly FriendDb _friendDb;
        private readonly IUserService _userService;

        public FriendService(ILogger<FriendService> logger, IUserService userService, FriendDb friendDb)
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

        public List<Friends> GetFriendsRequestByUserId(string userId)
        {
            var foundFriendsRequisition = _friendDb.Friend.
                Where(f => f.ReceiverId == userId && f.ConfirmationDate == null).ToList();

            return foundFriendsRequisition;
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

        public async Task<Friends> CreateRequestFriend(string requesterId, string receiverUsername)
        {
            var user = _userService.GetUserByUsername(receiverUsername);
            var newFriend = new Friends(
                   requesterId: requesterId,
                   receiverId: user.Id,
                   status: Status.Waiting
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
