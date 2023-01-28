using HttpHost.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace HttpHost.Data
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
