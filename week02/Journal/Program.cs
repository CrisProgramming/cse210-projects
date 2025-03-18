using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; } // Added Mood Tracker

    public Entry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }
    
    public override string ToString()
    {
        return $"Date: {Date}\nMood: {Mood}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void WriteNewEntry()
    {
        Random rnd = new Random();
        string prompt = prompts[rnd.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        Console.Write("How was your mood today (Happy, Sad, Excited, etc.)? ");
        string mood = Console.ReadLine();
        
        entries.Add(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response, mood));
        SaveJournal(); // Auto-Save Feature
        Console.WriteLine("Entry saved and journal auto-saved.\n");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournal()
    {
        Console.Write("Enter filename to save journal (or press Enter for default 'journal.json'): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename)) filename = "journal.json";
        
        string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved successfully in JSON format.\n");
    }

    public void LoadJournal()
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }
        string json = File.ReadAllText(filename);
        entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
        Console.WriteLine("Journal loaded successfully from JSON.\n");
    }
}

class Program
{
    static void Main()
    {
        // Enhancements beyond core requirements:
        // 1. JSON Storage: The journal now saves entries in a structured JSON format for better readability and compatibility.
        // 2. Mood Tracker: Users can now log their mood along with their journal entry for better emotional tracking.
        // 3. Auto-Save Feature: The journal automatically saves after each entry, preventing data loss.
        
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": journal.WriteNewEntry(); break;
                case "2": journal.DisplayJournal(); break;
                case "3": journal.SaveJournal(); break;
                case "4": journal.LoadJournal(); break;
                case "5": return;
                default: Console.WriteLine("Invalid option, try again."); break;
            }
        }
    }
}
