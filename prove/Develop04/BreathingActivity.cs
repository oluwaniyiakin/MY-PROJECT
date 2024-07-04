using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        Start();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            DisplayCountdown(4); // Pause for 4 seconds

            Console.WriteLine("Breathe out...");
            DisplayCountdown(6); // Pause for 6 seconds
        }

        End();
    }
}
