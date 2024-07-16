using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");

        GoalManager manager = new GoalManager();

        // User input loop
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(manager);
                    break;
                case "2":
                    RecordEvent(manager);
                    break;
                case "3":
                    manager.DisplayGoals();
                    Console.WriteLine($"Total Score: {manager.Score}");
                    break;
                case "4":
                    SaveGoals(manager);
                    break;
                case "5":
                    LoadGoals(manager);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal(GoalManager manager)
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Level Goal");

        Console.Write("Choose an option: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, points));
                break;
            case "3":
                Console.Write("Enter required count: ");
                int requiredCount = int.Parse(Console.ReadLine());

                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());

                manager.AddGoal(new ChecklistGoal(name, points, requiredCount, bonusPoints));
                break;
            case "4":
                Console.Write("Enter level: ");
                int level = int.Parse(Console.ReadLine());

                manager.AddGoal(new LevelGoal(name, points, level));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void RecordEvent(GoalManager manager)
    {
        Console.Write("Enter goal index to record event: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        manager.RecordEvent(index);
    }

    static void SaveGoals(GoalManager manager)
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        manager.Save(filename);
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals(GoalManager manager)
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();
        manager.Load(filename);
        Console.WriteLine("Goals loaded successfully.");
    }
}
