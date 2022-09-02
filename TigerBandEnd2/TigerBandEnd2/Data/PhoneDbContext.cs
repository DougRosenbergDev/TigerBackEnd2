using Microsoft.EntityFrameworkCore;
using TigerBandEnd2.Models;

namespace TigerBandEnd2.Data
{
    public class PhoneDbContext : DbContext
    {
        public PhoneDbContext(DbContextOptions<PhoneDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>()
                .HasOne<User>(p => p.User)
                .WithMany(d => d.Plans)
                .HasForeignKey(f => UserId);
        }
    }
}
