using System;

namespace HttpHost.Domain.Models
{
    public class Users
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberResolvedAccounts { get; set; } = 0;
        public int NumberUnresolvedAccounts { get; set; } = 0;

        public Users()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Users(string email, string passwordHash, string userName, string firstName, string lastName, int numberResolvedAccounts = 0, int numberUnresolvedAccounts = 0)
        {
            Id = Guid.NewGuid().ToString();
            Email = email;
            EmailConfirmed = false;
            TwoFactorEnabled = false;
            AccessFailedCount = 0;
            PasswordHash = passwordHash;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            NumberResolvedAccounts = numberResolvedAccounts;
            NumberUnresolvedAccounts = numberUnresolvedAccounts;
        }
    }
}
