// I created another activity to where the user can relax and visualize a specific prompt that is given to them.
// This will help the user calm down and have a clear mind. 

using System;

class Program
{
    static void Main(string[] args)
    {

        string selection = "";
        Console.WriteLine("Welcome to the Mindfulness Program");

        while (true)
        {
            // This is the main menu.
            Console.WriteLine(" ");
            Console.WriteLine("Activity Menu");
            Console.WriteLine("Choose what you would like to do:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Visualize Activity");
            Console.WriteLine("5. Quit");
            Console.Write(">");

            selection = Console.ReadLine();

            if (selection == "5")
            {
                Console.WriteLine("GoodBye!!"); // If they choose to leave.
                break;
            }

            // If statement for Breathing Activity.
            if (selection == "1")
            {

                Breathing breath = new Breathing(0);
                breath.StartingActivity();

                breath.RunningBreath();

            }

            // If statement for Reflection Activity.
            else if (selection == "2")
            {
                Reflection reflect = new Reflection(0);
                reflect.StartingActivity();

                reflect.RunReflection();

            }

            // If statement for Listing Activity.
            else if (selection == "3")
            {
                Listing list = new Listing(0);
                list.StartingActivity();

                list.RunListing();
            }

            // If statement for Visual Activity.
            else if (selection == "4")
            {
                Visual watch = new Visual(0);
                watch.StartingActivity();

                watch.RunVisual();
            }

        }
    }
}