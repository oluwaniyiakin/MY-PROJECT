using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Declare and initialize a new list to hold the numbers
        List<int> numbers = new List<int>();
        
        // Read numbers from the user until they enter 0
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Compute the sum of the numbers in the list
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Compute the average of the numbers in the list
        double average = (double)sum / numbers.Count;

        // Find the maximum number in the list
        int max = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        // Display the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge 1: Find the smallest positive number
        int? smallestPositive = null;
        foreach (int num in numbers)
        {
            if (num > 0 && (smallestPositive == null || num < smallestPositive))
            {
                smallestPositive = num;
            }
        }

        if (smallestPositive.HasValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        // Stretch Challenge 2: Sort the numbers in the list and display the sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
