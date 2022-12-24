using Microsoft.EntityFrameworkCore;
using HttpHost.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HttpHost.Data
{

    public class UserDb : DbContext
    {
        public UserDb(DbContextOptions<UserDb> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(t => t.Id);
        }

        public DbSet<User> All => Set<User>();
    }
}
