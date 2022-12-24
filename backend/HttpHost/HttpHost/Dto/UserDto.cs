namespace HttpHost.Dto
{
    public class UserDto
    {
        public string? Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberResolvedAccounts { get; set; }
        public int NumberUnresolvedAccounts { get; set; }
    }
}
