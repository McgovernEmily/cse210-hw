using System;
using System.Data;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        UserStorage userstorage = new UserStorage();
        //Tracker tracker;
        MealTracker mealTracker = new MealTracker();
        string filePath = "protein_data.txt";


        string newOld = "";
        string selection = "";

        Console.WriteLine();

        // This will ask if the user has an existing account.
        Console.WriteLine("Welcome to Your Protein Tracker");
        Console.WriteLine("Do you have an existing account? (YES or NO)");
        Console.Write(">");

        newOld = Console.ReadLine();

        // If user does then if will find it.
        if (newOld == "YES" | newOld == "yes")
        {
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();
            User user = userstorage.GetUser(userName);

            // If it finds the user, then they will welcome them.
            if (userName != null)
            {
                Console.WriteLine($"Welcome back {user.GetName()}!");
            }
            else
            {
                Console.WriteLine("User not found. Please create a new account.");
            }
        }

        // If they do not have an account they will create one.
        else if (newOld == "NO" | newOld == "no")
        {

            // User information input.
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your weight (kg): ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Enter your gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter you activity level (1 nothing - 5 Athletes and Bodybuilders): ");
            int activity = int.Parse(Console.ReadLine());
            Console.WriteLine("What is your protein Goal: ");
            double proteinGoal = double.Parse(Console.ReadLine());

            // Adding the user information to the list.
            userstorage.AddUser(name, weight, gender, activity, proteinGoal);
        }

        while (true)
        {
            Console.WriteLine();

            // The main menu of tracking protein.
            Console.WriteLine("Please Select From the Menu:");
            Console.WriteLine("1. Create Protein Entry");
            Console.WriteLine("2. List Protein Intake");
            Console.WriteLine("3. Upload Protein Intake to File");
            Console.WriteLine("4. Load in Protein File");
            Console.WriteLine("5. Quit");

            selection = Console.ReadLine();
            if (selection == "1")
            {
                // Adding the meals / creating a meal.
                mealTracker.AddMeals();
            }
            else if (selection == "2")
            {
                // List the protein intake verse the goal.
                Console.WriteLine("Still working on it.");
            }
            else if (selection == "3")
            {
                // FileManager for uploading the user info/protein to a file.
            }
            else if (selection == "4")
            {
                // FileManager for loading a file into the program.
            }
            else if (selection == "5")
            {
                break;
            }
        }
    }
}