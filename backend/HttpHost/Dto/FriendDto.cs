namespace HttpHost.Dto
{
    public class FriendDto
    {
        public string RequesterId { get; set; }
        public string ReceiverId { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public char Status { get; set; }
    }
}
