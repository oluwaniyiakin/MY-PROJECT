using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Scripture object with the desired scripture text and reference
            var scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");

            // Clear the console initially
            Console.Clear();

            // Display the scripture with the reference
            DisplayScripture(scripture);

            // Wait for user input to continue or quit
            while (true)
            {
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else if (input == "")
                {
                    // Hide a few random words in the scripture
                    scripture.HideRandomWords();

                    // Clear console and display updated scripture
                    Console.Clear();
                    DisplayScripture(scripture);

                    // Check if all words are hidden, then end the program
                    if (scripture.AllWordsHidden())
                    {
                        Console.WriteLine("\nAll words in scripture are hidden. Exiting program...");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please press Enter to continue or type 'quit' to exit.");
                }
            }
        }

        static void DisplayScripture(Scripture scripture)
        {
            Console.WriteLine($"Scripture: {scripture.Reference}");
            Console.WriteLine();

            // Display each word in the scripture, hiding words that are marked as hidden
            foreach (var word in scripture.Words)
            {
                if (word.IsHidden)
                    Console.Write("_ ");
                else
                    Console.Write($"{word.Text} ");
            }

            Console.WriteLine();
        }
    }

    class Scripture
    {
        private string _reference;
        private List<Word> _words;

        public string Reference => _reference;
        public IReadOnlyList<Word> Words => _words;

        public Scripture(string reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            // Split the text into words and initialize Word objects
            string[] wordsArray = text.Split(' ');
            foreach (var wordText in wordsArray)
            {
                _words.Add(new Word(wordText));
            }
        }

        public void HideRandomWords()
        {
            Random random = new Random();

            // Select a random number of words to hide (can be adjusted based on requirements)
            int wordsToHide = random.Next(1, 4);

            // Get visible words
            List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();

            // Ensure we have enough visible words to hide
            if (visibleWords.Count < wordsToHide)
                wordsToHide = visibleWords.Count;

            // Hide random words from the visible list
            for (int i = 0; i < wordsToHide; i++)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].IsHidden = true;
                visibleWords.RemoveAt(index); // Remove the hidden word from visible list
            }
        }

        public bool AllWordsHidden()
        {
            return _words.All(word => word.IsHidden);
        }
    }

    class Word
    {
        private string _text;
        private bool _isHidden;

        public string Text => _text;
        public bool IsHidden
        {
            get { return _isHidden; }
            set { _isHidden = value; }
        }

        public Word(string text)
        {
            _text = text;
            _isHidden = false; // By default, words are not hidden
        }
    }
}