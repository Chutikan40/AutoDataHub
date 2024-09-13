using AutoDataHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoDataHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarsViewModel> Cars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasNoKey(); // กำหนดให้ LoginRequestModel เป็น Keyless Entity
        }
    }
}
