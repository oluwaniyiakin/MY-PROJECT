using System;

class Program
{
    static void Main()
    {
        // Prompt the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int percentage;

        // Ensure the input is a valid integer
        if (int.TryParse(input, out percentage))
        {
            // Variable to store the letter grade
            string letterGrade = "";

            // Determine the letter grade
            if (percentage >= 90)
            {
                letterGrade = "A";
            }
            else if (percentage >= 80)
            {
                letterGrade = "B";
            }
            else if (percentage >= 70)
            {
                letterGrade = "C";
            }
            else if (percentage >= 60)
            {
                letterGrade = "D";
            }
            else
            {
                letterGrade = "F";
            }

            // Variable to store the sign (+, -, or empty)
            string sign = "";

            // Determine the sign for the grade
            int lastDigit = percentage % 10;

            if (letterGrade != "A" && letterGrade != "F")
            {
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }
            else if (letterGrade == "A" && lastDigit < 3)
            {
                sign = "-";
            }

            // Print the letter grade with sign
            Console.WriteLine($"Your grade is: {letterGrade}{sign}");

            // Check if the student passed the course
            if (percentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Unfortunately, you did not pass the course. Better luck next time.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid grade percentage.");
        }
    }
}
