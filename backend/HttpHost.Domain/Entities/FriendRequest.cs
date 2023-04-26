using System;

namespace HttpHost.Domain.Models
{
    public class FriendRequest
    {
        public string Id { get; set; }
        public string RequesterId { get; set; }
        public string ReceiverId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public FriendRequestStatus Status { get; set; }

        public FriendRequest(string requesterId, string receiverId, FriendRequestStatus status)
        {
            Id = Guid.NewGuid().ToString();
            RequesterId = requesterId;
            ReceiverId = receiverId;
            RequestDate = DateTime.Now;
            Status = status;
        }

        public void Confirm()
        {
            Status = FriendRequestStatus.Approved;
            ConfirmationDate = DateTime.Now;
        }
    }

    public enum FriendRequestStatus
    {
        Approved,
        Decline,
        Waiting
    }
}
