using System;

class Program
{
    static void Main()
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate a random magic number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // 1 to 100 inclusive

            int guess = -1; // Initialize the guess to a value that is not the magic number
            int attempts = 0; // Counter for the number of attempts

            while (guess != magicNumber)
            {
                // Ask the user for a guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++; // Increment the attempts counter

                // Check if the guess is higher, lower, or equal to the magic number
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {attempts} attempts!");
                }
            }

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
    }
}
