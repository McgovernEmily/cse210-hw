using System.IO;
using System.Runtime;
using Microsoft.VisualBasic;

public class Journal
{
    // Creates the list for the journal entries.
    public List<Entry> _entries = new List<Entry>();

    // How to add an entry and it calls the Entry class.
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Displays the entries from what you have done.
    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    // How to save to the file they want it saved to.
    public void SaveFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, append: true))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine($"{entry._date} | {entry._prompt} | {entry._response}");

            }
        }
    }

    // It will display everything in the file they want.
    public void LoadFile (string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];
            Console.WriteLine($"Date:{date}, Prompt:{prompt}, Response:{response}");
        }

    }

    // This will find the journal entry by the date.
    public void FindEntry(string filename)
    {
       string[] lines = System.IO.File.ReadAllLines(filename); 

       bool notFound = false;

        Console.WriteLine("Please enter the date you want to find");
        Console.Write(">");
        string userDate = Console.ReadLine().Trim();

       foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string date = parts[0].Trim();
            string prompt = parts[1].Trim();
            string response = parts[2];

            if (userDate == date)
            {
                Console.WriteLine($"Date:{date}, Prompt:{prompt}, Response:{response}");
                notFound = true;
            }
        }
        if (!notFound)
        {
            Console.WriteLine("There was no journal entry for that date");
        }
    }
}