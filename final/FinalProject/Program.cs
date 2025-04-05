// Websites used for help on syntax and other things: https://www.codecademy.com/resources/docs/c-sharp/classes
// https://www.w3schools.com/cs/cs_classes.php, https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/
// https://stackoverflow.com/questions/9823836/checking-if-a-variable-is-of-data-type-double
using System;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        UserStorage userstorage = new UserStorage();
        MealTracker mealTracker = new MealTracker();
        // File that will be used for the program for storing user info.
        string filePath = "protein_data.txt";
        FileManager fileManager = new FileManager(filePath);


        string newOld = "";
        string selection = "";

        Console.WriteLine();

        // This will ask if the user has an existing account.
        Console.WriteLine("-----Welcome to Your Protein Tracker------");
        Console.WriteLine("Do you have an existing account? (YES or NO)");
        Console.Write(">");

        newOld = Console.ReadLine().ToLower();

        // If user does then if will find it.
        if (newOld == "yes")
        {
            // Asking user for the name.
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();
            User user = userstorage.GetUser(userName);

            // If it finds the user, then they will welcome them.
            if (fileManager.FindingUserFile(userName))
            {
                Console.WriteLine($"Welcome back {userName}!");
            }
            else
            {
                Console.WriteLine("User not found. Please create a new account.");
                // User information input.
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();

                // Asking the user for their weight.
                Console.Write("Enter your weight (kg): ");
                double weight;

                // If the weight is not a double then it will ask again for correct input.
                while (!double.TryParse(Console.ReadLine(), out weight))
                {
                    Console.Write("Not correct. Enter your weight (kg): ");
                }

                // Asking user for their gender.
                Console.Write("Enter your gender: ");
                string gender = Console.ReadLine();

                // Asking the user for their activity level.
                Console.Write("Enter your activity level (1 nothing - 5 Athletes and Bodybuilders): ");
                int activity;

                // If activity level is not an int, then it will ask again.
                while (!int.TryParse(Console.ReadLine(), out activity))
                {
                    Console.Write("Not correct. Enter your activity level (1 nothing - 5 Athletes and Bodybuilders):");
                }

                // Calling the User class to get the CalculateProtein for finding the recommendation.
                double recommended = User.CalculateProtein(weight, activity);
                Console.WriteLine($"Here is your protein recommendation: {recommended}");

                // Asking user for the protein goal they want to use.
                Console.Write("What is your protein goal: ");
                double proteinGoal;

                // If the protein goal is not a double then it will ask again.
                while (!double.TryParse(Console.ReadLine(), out proteinGoal))
                {
                    Console.Write("Not correct. Enter your protein goal: ");
                }

                // Adding the user information to the list.
                userstorage.AddUser(name, weight, gender, activity, proteinGoal);
                Console.WriteLine("Account Created!");
            }
        }

        // If they do not have an account they will create one.
        else if (newOld == "no")
        {

            // User information input.
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            // Asking user for their weight.
            Console.Write("Enter your weight (kg): ");
            double weight;

            // If user input not a double, then it will ask again.
            while (!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.Write("Not correct. Enter your weight (kg): ");
            }

            // Asking user for their gender.
            Console.Write("Enter your gender: ");
            string gender = Console.ReadLine();

            // Asking user for their activity level.
            Console.Write("Enter your activity level (1 nothing - 5 Athletes and Bodybuilders): ");
            int activity;

            // If they input not an int, then it will ask again for the correct input.
            while (!int.TryParse(Console.ReadLine(), out activity))
            {
                Console.Write("Not correct. Enter your activity level (1 nothing - 5 Athletes and Bodybuilders):");
            }

            // Giving the user the recommended protein using User class and CalculateProtein.
            double recommended = User.CalculateProtein(weight, activity);
            Console.WriteLine($"Here is your protein recommendation: {recommended}");

            // Asking the user their protein goal.
            Console.Write("What is your protein goal: ");
            double proteinGoal;

            //  If the protein goal is not a double, then it will ask again for correct input.
            while (!double.TryParse(Console.ReadLine(), out proteinGoal))
            {
                Console.Write("Not correct. Enter your protein goal: ");
            }

            // Adding the user information to the list.
            userstorage.AddUser(name, weight, gender, activity, proteinGoal);
            Console.WriteLine("Account Created!");
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
            Console.WriteLine("5. Reset Protein");
            Console.WriteLine("6. Quit");

            // Adding a protein entry.
            selection = Console.ReadLine();
            if (selection == "1")
            {
                // Adding the meals / creating a meal.
                mealTracker.AddMeals();
            }

            // Listing the protein taken.
            else if (selection == "2")
            {
                // Asking user for name to make sure it is correct user.
                Console.WriteLine("Enter name:");
                string userName = Console.ReadLine();
                User user = userstorage.GetUser(userName);

                Tracker tracker = new Tracker(user.GetProteinGoal());

                // Finding the protein from each meal.
                foreach (var meal in mealTracker.GetMeals())
                {
                    tracker.IntakeUpdate(meal.GetProtein());
                }

                Console.WriteLine($"User: {user.GetName()}");
                Console.WriteLine(tracker.GetProgress());

                // Getting the sum.
                double total = mealTracker.GetMeals().Sum(meal => meal.GetProtein());
                double proteinGoal = user.GetProteinGoal();

                // List the protein intake verse the goal.
                if (total >= proteinGoal)
                {
                    Console.WriteLine("You did it!!!!");
                }
                else
                {
                    Console.WriteLine($"You need {proteinGoal - total} grams to reach your goal.");
                }
            }

            // Saving the user info to the file.
            else if (selection == "3")
            {
                fileManager.SaveToFile(userstorage, mealTracker);
            }

            // Loading the user info to the program.
            else if (selection == "4")
            {
                fileManager.LoadFromFile(userstorage, mealTracker);
            }

            // Having the user info cleared
            else if (selection == "5")
            {
                mealTracker.ClearMeal();

                // Verifying the name associated with the account.
                Console.WriteLine("Enter name to verify reset: ");
                string userName = Console.ReadLine();
                User user = userstorage.GetUser(userName);

                if (user != null)
                {
                    // Resetting the protein goal completion.
                    Tracker trackerRest = new Tracker(user.GetProteinGoal());
                    trackerRest.ResetProtein();
                    Console.WriteLine("Protein tracker is reset.");
                }

                else
                {
                    Console.WriteLine("User not found and reset not initiated.");
                }
            }

            // Ending the program.
            else if (selection == "6")
            {
                Console.WriteLine("GoodBye!!");
                break;
            }
        }
    }
}