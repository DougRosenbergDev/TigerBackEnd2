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
            //bill (b) combines entities

            //modelBuilder.Entity<User>()
            //    .HasKey(b => b.UserId);

            modelBuilder.Entity<Plan>()
                .HasOne(p => p.User)
                .WithMany(d => d.Plans)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Device>()
                 .HasOne(p => p.Plan)
                 .WithMany(d => d.Devices)
                 .HasForeignKey(b => b.PlanId);

            modelBuilder.Entity<Device>()
                .HasIndex(p => p.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
