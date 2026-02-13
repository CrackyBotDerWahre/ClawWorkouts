-- T-SQL Script for ClawWorkouts Database Schema

-- Create UserProfiles Table
CREATE TABLE [dbo].[UserProfiles] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Name] NVARCHAR(100) NOT NULL,
    [HeightCm] FLOAT NOT NULL,
    [TargetWeightKg] FLOAT NOT NULL,
    [GoalDate] DATETIME2 NOT NULL
);

-- Create WeightEntries Table
CREATE TABLE [dbo].[WeightEntries] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Date] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    [WeightKg] FLOAT NOT NULL,
    [Note] NVARCHAR(MAX) NULL
);

-- Create WorkoutSessions Table
CREATE TABLE [dbo].[WorkoutSessions] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Date] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    [WorkoutType] NVARCHAR(50) NOT NULL, -- Push, Pull, Legs, Cardio
    [DurationMinutes] INT NOT NULL,
    [Notes] NVARCHAR(MAX) NULL
);

-- Create ExerciseEntries Table (Child of WorkoutSessions)
CREATE TABLE [dbo].[ExerciseEntries] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [WorkoutSessionId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(200) NOT NULL,
    [Sets] INT NOT NULL,
    [Reps] INT NOT NULL,
    [WeightKg] FLOAT NOT NULL,
    CONSTRAINT [FK_ExerciseEntries_WorkoutSessions] FOREIGN KEY ([WorkoutSessionId]) 
        REFERENCES [dbo].[WorkoutSessions] ([Id]) ON DELETE CASCADE
);

-- Insert initial data (Template)
-- INSERT INTO [dbo].[UserProfiles] (Name, HeightCm, TargetWeightKg, GoalDate)
-- VALUES ('YourName', 180, 85.0, '2026-12-31');

-- Insert initial weight (Template)
-- INSERT INTO [dbo].[WeightEntries] (WeightKg, Date, Note)
-- VALUES (100.0, GETUTCDATE(), 'Starting Point');
