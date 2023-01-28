namespace HttpHost.Dto
{
    public class UserDto
    {
        public string? Id;
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? EmailConfirmed { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public int? AccessFailedCount { get; set; }
        public int? NumberResolvedAccounts { get; set; }
        public int? NumberUnresolvedAccounts { get; set; }
    }
}
