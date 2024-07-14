using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");

        GoalManager manager = new GoalManager();

        // Add some sample goals
        manager.AddGoal(new SimpleGoal("Run a marathon", 1000));
        manager.AddGoal(new EternalGoal("Read scriptures", 100));
        manager.AddGoal(new ChecklistGoal("Attend temple", 50, 10, 500));

        // Record some events
        manager.RecordEvent(0); // Complete marathon
        manager.RecordEvent(1); // Read scriptures
        manager.RecordEvent(2); // Attend temple

        // Display goals
        manager.DisplayGoals();

        // Save and load goals
        manager.Save("goals.txt");
        manager.Load("goals.txt");

        // Display updated goals
        manager.DisplayGoals();
        Console.WriteLine($"Total Score: {manager.Score}");

        // Exceeding requirements: Additional feature - levels
        manager.AddGoal(new LevelGoal("Complete C# course", 200, 5));
        manager.RecordEvent(3); // Progress in C# course
        manager.DisplayGoals();
        Console.WriteLine($"Total Score: {manager.Score}");
    }
}
