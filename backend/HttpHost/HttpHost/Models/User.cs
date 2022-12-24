namespace HttpHost.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberResolvedAccounts { get; set; } = 0;
        public int NumberUnresolvedAccounts { get; set; } = 0;

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public User(string firstName, string lastName, int numberResolvedAccounts = 0, int numberUnresolvedAccounts = 0)
        {
            Id = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
            NumberResolvedAccounts = numberResolvedAccounts;
            NumberUnresolvedAccounts = numberUnresolvedAccounts;
        }
    }
}
