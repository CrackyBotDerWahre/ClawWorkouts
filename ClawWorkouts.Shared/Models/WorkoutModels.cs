using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClawWorkouts.Shared.Models
{
    public class UserProfile
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public double HeightCm { get; set; }
        public double TargetWeightKg { get; set; }
        public DateTime GoalDate { get; set; }
    }

    public class WeightEntry
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public double WeightKg { get; set; }
        public string? Note { get; set; }
    }

    public class WorkoutSession
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string WorkoutType { get; set; } = "Push"; // Push, Pull, Legs, Cardio
        public int DurationMinutes { get; set; }
        public string? Notes { get; set; }
        public List<ExerciseEntry> Exercises { get; set; } = new();
    }

    public class ExerciseEntry
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double WeightKg { get; set; }
    }
}
