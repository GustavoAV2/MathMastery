using System;

namespace HttpHost.Domain.Models
{
    public class Friends
    {
        public string Id { get; set; }
        public string RequesterId { get; set; }
        public string ReceiverId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public Status Status { get; set; }

        public Friends(string requesterId, string receiverId, Status status)
        {
            Id = Guid.NewGuid().ToString();
            RequesterId = requesterId;
            ReceiverId = receiverId;
            RequestDate = DateTime.Now;
            Status = status;
        }

        public void Confirm()
        {
            Status = Status.Approved;
            ConfirmationDate = DateTime.Now;
        }
    }

    public enum Status
    {
        Approved,
        Decline,
        Waiting
    }
}
