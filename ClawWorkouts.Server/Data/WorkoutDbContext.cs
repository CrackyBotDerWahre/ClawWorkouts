using Microsoft.EntityFrameworkCore;
using ClawWorkouts.Shared.Models;

namespace ClawWorkouts.Server.Data
{
    public class WorkoutDbContext : DbContext
    {
        public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options) { }

        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<WeightEntry> WeightEntries { get; set; }
        public DbSet<WorkoutSession> Workouts { get; set; }
        public DbSet<ExerciseEntry> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship: One Workout -> Many Exercises
            modelBuilder.Entity<WorkoutSession>()
                .HasMany(w => w.Exercises)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
