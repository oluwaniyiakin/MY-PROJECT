using System;
using System.Collections.Generic;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Category { get; set; }

    public JournalEntry(string prompt, string response, string date, string category)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Category = category;
    }

    public override string ToString()
    {
        return $"{Date}: {Category} - {Prompt}\n{Response}\n";
    }
}

public class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(string prompt, string response, string date, string category)
    {
        JournalEntry entry = new JournalEntry(prompt, response, date, category);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (JournalEntry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename))
        {
            foreach (JournalEntry entry in entries)
            {
                file.WriteLine($"{entry.Date},{entry.Category},{entry.Prompt},{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string date = parts[0];
            string category = parts[1];
            string prompt = parts[2];
            string response = parts[3];
            entries.Add(new JournalEntry(prompt, response, date, category));
        }
    }

    public List<JournalEntry> SearchByPrompt(string prompt)
    {
        List<JournalEntry> results = new List<JournalEntry>();
        foreach (JournalEntry entry in entries)
        {
            if (entry.Prompt.ToLower().Contains(prompt.ToLower()))
            {
                results.Add(entry);
            }
        }
        return results;
    }
}

public class Program
{
    private static Journal journal = new Journal();
    private static Random random = new Random();

    public static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Journal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Search entries by prompt");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    SearchEntries();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                    break;
            }
        }
    }

    private static void WriteNewEntry()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        string randomPrompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();
        Console.Write("Enter category (e.g., Personal, Work, Reflection): ");
        string category = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        journal.AddEntry(randomPrompt, response, date, category);
    }

    private static void DisplayJournal()
    {
        journal.DisplayEntries();
    }

    private static void SaveJournalToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved successfully.");
    }

    private static void LoadJournalFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded successfully.");
    }

    private static void SearchEntries()
    {
        Console.Write("Enter prompt keyword to search: ");
        string prompt = Console.ReadLine();
        List<JournalEntry> results = journal.SearchByPrompt(prompt);
        if (results.Count == 0)
        {
            Console.WriteLine("No entries found matching the prompt.");
        }
        else
        {
            Console.WriteLine("Search Results:");
            foreach (JournalEntry entry in results)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
