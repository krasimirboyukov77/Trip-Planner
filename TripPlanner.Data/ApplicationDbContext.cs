using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripPlanner.Data.Models;

namespace TripPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TripPlanner_DataBase;Trusted_Connection=True;MultipleActiveResultSets=true; Encrypt=False");
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TripUser>()
                .HasKey(tu=> new {tu.TripId, tu.UserId});
        }
    }
}
