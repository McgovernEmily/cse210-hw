// To exceed this program, I added a menu to where the user can choose either to start with all the words from the scripture
// or start with no words from the scripture. The no words start will allow the user to start with not words, just the reference
// and if they can't figure it out the user can hit enter and see either 1-4 word from the scripture.

using System;
using System.IO.Pipes;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Program
{
        static void Main(string[] args)
    {
        string selection = "";
        bool answer = false;

        Scripture scripture = new Scripture
        (
            // The scripture.
            new Reference("John", 3, 16), new List<string> 
            {
                "For", "God", "so", "loved", "the", "world", "that", "he", "gave", 
                "his", "only", "begotten", "Son,", "that", "whosoever", 
                "believeth", "in", "him", "should", "not", "perish,", 
                "but", "have", "everlasting", "life."
            }
        );

        Console.WriteLine("Welcome to the Scripture Memorizer!");

        do
        {
            // This is the main menu
            Console.WriteLine(" ");
            Console.WriteLine("Scripture Menu");
            Console.WriteLine("Choose how you want to start memorizing");
            Console.WriteLine("1. Start Full Scripture");
            Console.WriteLine("2. Start With No Words");
            Console.WriteLine("3. Quit");
            Console.Write(">");

            selection = Console.ReadLine();

            switch(selection)
            {
                case "1":
                    
                    // While loop that goes through until the user hits quit.
                    while(answer == false)
                    {
                        
                        scripture.Display();
                        UserInput(ref answer);

                        // This chooses 1-4 amount of words to get rid of.
                        Random randnum = new Random();
                        int numOfWords = randnum.Next(1,4);
                        scripture.HideWord(numOfWords);
                    }
                    break;
                
                case "2":

                    // This will start the unhide words.
                    scripture.NoWords();    
                    while(answer == false)
                    {
                        scripture.Display();
                        UserInput(ref answer);
                        
                        // This chooses 1-4 amount of words to get to see.
                        Random randnum = new Random();
                        int numOfWords = randnum.Next(1,4);
                        scripture.UnHide(numOfWords);
                    }
                    break;
                
                case "3":

                    // Leaves the menu.
                    Console.WriteLine("See ya later!");
                    answer = true;
                    break;

                
            }
        }while(answer == false);

        // The user's input and if they hit quit.
        static void UserInput(ref bool answer)
        {
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input == "quit")
            {
                answer = true;
            }
        }

    }
    
}