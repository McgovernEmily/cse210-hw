// To exceeding requirements for the eternal goals, I created a way to count the number of times it was completed.
// I also added a level up feature. When the user gets to 500 points for level 0, they level up to level 1. Then after
// that, the user then needs to get 1000 more points to level up to the next levels.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager(0);

        string selection = "";

        while (true)
        {
            Console.WriteLine();
            goalManager.DisplayScore();

            // This is the main menu.
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to GoalCreator");
            Console.WriteLine("Please Choose From the Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Completion");
            Console.WriteLine("6. Quit");
            Console.Write(">");

            selection = Console.ReadLine();

            if (selection == "6")
            {
                Console.WriteLine("GoodBye!!"); // If they choose to leave.
                break;
            }

            // If statement for creating a new goals.
            if (selection == "1")
            {
                // Calling the Goal class to create a goal.
                Goals newGoal = goalManager.CreateGoal();
                if (newGoal != null)
                {
                    goalManager.AddGoal(newGoal);
                }
            }

            // If statement for listing goals.
            else if (selection == "2")
            {
                Console.WriteLine();
                goalManager.ListGoals();
            }

            // If statement for saving goals to a file.
            else if (selection == "3")
            {
                goalManager.SaveToFile();
            }

            // If statement for loading goals to the program.
            else if (selection == "4")
            {
                goalManager.LoadFromFile();
            }

            // If statement for completing a goal and recording it.
            else if (selection == "5")
            {
                goalManager.CompleteGoal();
                goalManager.CheckLevel();
            }

        }
    }
}