using HttpHost.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpHost.Database.Data
{

    public class UserDb : DbContext
    {
        public UserDb(DbContextOptions<UserDb> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(t => t.Id);
        }

        public DbSet<User> User { get; set; }
        public DbSet<User> All => Set<User>();
    }
}
