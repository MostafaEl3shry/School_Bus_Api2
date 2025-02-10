using Microsoft.EntityFrameworkCore;
using School_Bus_Api.Model;

namespace School_Bus_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrationModel>().HasIndex(x => x.studentPhoneNumber).IsUnique();
            modelBuilder.Entity<RegistrationModel>().HasIndex(x => x.parentPhoneNumber).IsUnique();

            modelBuilder.Entity<BusModel>().HasIndex(x => x.BusCode).IsUnique();

            modelBuilder.Entity<DriverModel>().HasIndex(x => x.DriverCode).IsUnique();
            modelBuilder.Entity<DriverModel>().HasIndex(x => x.DriverPhoneNumber).IsUnique();
        }

        public DbSet<RegistrationModel> registrations { get; set; }
        public DbSet<BusModel> buses { get; set; }
        public DbSet<DriverModel> drivers { get; set; }
    }
}
