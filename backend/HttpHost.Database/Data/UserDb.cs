using HttpHost.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HttpHost.Database.Data
{

    public class UserDb : DbContext
    {
        public UserDb(DbContextOptions<UserDb> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(t => t.Id);
        }

        public DbSet<Users> User { get; set; }
        public DbSet<Users> All => Set<Users>();
    }
}
