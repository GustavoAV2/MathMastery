namespace HttpHost.Domain.Models
{
    public class FriendNotification
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public FriendRequestStatus Status { get; set; }
    }
}
