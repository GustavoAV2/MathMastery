using AutoMapper;
using HttpHost.Domain.Models;

namespace Gestor.BackWorks.Domain.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            MapFriend();
        }

        private void MapFriend()
        {
            CreateMap<User, FriendRequest>();
        }
    }
}