//For this assignment you will write a program to help people record the events of their day by 
//supplying prompts and then saving their responses along with the question and the date to a file.
//For exceeding the requirements I created a way for the user to look up a specific date and see the journal
//entries they made.


using System;
using System.Diagnostics;


class Program
{
    static void Main(string[] args)
    {
        string selection = "";
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to your Journal");

        do
        {
            // This is the main menu.
            Console.WriteLine(" ");
            Console.WriteLine("Journal Menu");
            Console.WriteLine("Choose what you would like to do:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Find Entry");
            Console.WriteLine("6. Quit");
            Console.Write(">");

            selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    AddEntry(journal, promptGenerator);
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.WriteLine("Enter the filename to load from:");
                    Console.Write(">");
                    string loadFilename = Console.ReadLine();
                    journal.SaveFile(loadFilename);
                    break;

                case "4":
                    Console.WriteLine("Enter the filename to save to:");
                    Console.Write(">");
                    string saveFilename = Console.ReadLine();
                    journal.LoadFile(saveFilename);
                    break;

                case "5":
                    Console.WriteLine("Enter the filename to load from:");
                    Console.Write(">");
                    string fileName = Console.ReadLine();
                    journal.FindEntry(fileName);
                    break;

                case "6":
                    Console.WriteLine("See ya later!");
                    break;
           }

        }while(selection != "6");

        static void AddEntry(Journal journal, PromptGenerator promptGenerator)
        {
            string prompt = promptGenerator.RandomPrompt();
            Console.WriteLine(prompt);

            string response = Console.ReadLine();

            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();

            Entry newEntry = new Entry(prompt, response, dateText);
            journal.AddEntry(newEntry);

        }

    }
}