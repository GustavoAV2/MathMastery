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
        public char Status { get; set; }

        public Friends(string requesterId, string receiverId, char status)
        {
            Id = Guid.NewGuid().ToString();
            RequesterId = requesterId;
            ReceiverId = receiverId;
            RequestDate = DateTime.Now;
            Status = status;
        }

        public void Confirm()
        {
            ConfirmationDate = DateTime.Now;
        }
    }
}
