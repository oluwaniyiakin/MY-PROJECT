using System;
using System.Collections.Generic;

class Program
{
    private static Dictionary<string, int> activityCount = new Dictionary<string, int>
    {
        { "BreathingActivity", 0 },
        { "ReflectingActivity", 0 },
        { "ListingActivity", 0 },
        { "GratitudeActivity", 0 }
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Exit");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectingActivity(),
                "3" => new ListingActivity(),
                "4" => new GratitudeActivity(),
                "5" => null,
                _ => throw new ArgumentOutOfRangeException()
            };

            if (activity == null)
            {
                break;
            }

            activity.Run();
            activityCount[activity.GetType().Name]++;
            Console.WriteLine($"{activity.GetType().Name} has been performed {activityCount[activity.GetType().Name]} times.");
        }
    }
}
