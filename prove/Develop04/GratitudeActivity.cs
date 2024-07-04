using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think about things you are grateful for in your life.",
        "List the people who have had a positive impact on you.",
        "Reflect on the small joys you experienced today.",
        "Consider the opportunities you have been given."
    };

    public GratitudeActivity() 
        : base("Gratitude", "This activity will help you reflect on things you are grateful for in your life. It will bring positivity and appreciation to your thoughts.")
    {
    }

    public override void Run()
    {
        Start();

        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine(prompt);

        Console.WriteLine("You have a few seconds to think about your response...");
        DisplayCountdown(5); // Pause for 5 seconds

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("List an item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items.");
        End();
    }
}
