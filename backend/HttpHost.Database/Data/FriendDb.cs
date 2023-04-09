using HttpHost.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpHost.Database.Data
{

    public class FriendDb : DbContext
    {
        public FriendDb(DbContextOptions<FriendDb> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friends>().HasKey(t => t.Id);
        }
        public DbSet<Friends> Friend { get; set; }
        public DbSet<Friends> All => Set<Friends>();
    }
}
