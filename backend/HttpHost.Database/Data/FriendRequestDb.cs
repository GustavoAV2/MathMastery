using HttpHost.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpHost.Database.Data
{

    public class FriendRequestDb : DbContext
    {
        public FriendRequestDb(DbContextOptions<FriendRequestDb> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendRequest>().HasKey(t => t.Id);
        }
        public DbSet<FriendRequest> Friend { get; set; }
        public DbSet<FriendRequest> All => Set<FriendRequest>();
    }
}
