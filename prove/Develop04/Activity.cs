using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void Start()
    {
        Console.WriteLine($"Starting {_name} Activity.");
        Console.WriteLine(_description);
        Console.Write("Enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        DisplayAnimation(3);
    }

    protected void End()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        DisplayAnimation(3);
    }

    protected void DisplayAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/"); Thread.Sleep(250); Console.Write("\b \b");
            Console.Write("-"); Thread.Sleep(250); Console.Write("\b \b");
            Console.Write("\\"); Thread.Sleep(250); Console.Write("\b \b");
            Console.Write("|"); Thread.Sleep(250); Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public abstract void Run();
}
