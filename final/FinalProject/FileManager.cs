using System.IO;

public class FileManager
{
    private string _fileName;

    // Constructor.
    public FileManager(string fileName)
    {
        _fileName = fileName;
    }

    // Saving the info to a file.
    public void SaveToFile(UserStorage userStorage, MealTracker mealTracker)
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            // How each variable for the user will be input to the file.
            foreach (var user in userStorage.GetAllUsers())
            {
                outputFile.WriteLine($"User | {user.GetName()} | {user.GetWeight()} | {user.GetProteinGoal()}");
            }

            // How each meal will be put int the file.
            foreach (var meal in mealTracker.GetMeals())
            {
                outputFile.WriteLine($"Meal | {meal.GetType().Name} | {meal.GetProtein()}");
            }
        }

        Console.WriteLine("Protein intake saved.");
    }

    // Loading a file into the program.
    public void LoadFromFile(UserStorage userStorage, MealTracker mealTracker)
    {

        // Seeing if the file is found.
        if (!File.Exists(_fileName))
        {
            Console.WriteLine("File Not Found! Try Again!");
            return;
        }

        using (StreamReader reader = new StreamReader(_fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(" | ");
                if (parts[0] == "User")
                {

                    // Setting the name, weight, and protein goal of the user found in the file.
                    string name = parts[1];
                    double weight = double.Parse(parts[2]);
                    double proteinGoal = double.Parse(parts[3]);
                    userStorage.AddUser(name, weight, "", 0, proteinGoal);
                }
                else if (parts[0] == "Meal")
                {

                    // Setting the meal type and protein found in the file.
                    string mealtype = parts[1];
                    double protein = double.Parse(parts[2]);

                    // Finding mealtype in Meal.
                    Meal meal = mealtype switch
                    {
                        "Breakfast" => new Breakfast(),
                        "Lunch" => new Lunch(),
                        "Dinner" => new Dinner(),
                        "Snack" => new Snack(),
                        _ => null
                    };

                    if (meal != null)
                    {
                        // Setting the protein and adding the meal to the list.
                        meal.SetProtein(protein);
                        mealTracker.GetMeals().Add(meal);
                    }
                }
            }
            Console.WriteLine("Protein intake loaded!");
        }
    }

    // Finding the user in the file.
    public bool FindingUserFile(string userName)
    {

        // Seeing if the file exists.
        if (!File.Exists(_fileName))
        {
            return false;
        }

        using (StreamReader read = new StreamReader(_fileName))
        {
            string line;
            while ((line = read.ReadLine()) != null)
            {

                // Finding the user in the file.
                var parts = line.Split(" | ");
                if (parts[0] == "User" && parts[1].Equals(userName))
                {
                    return true;
                }
            }
        }

        return false;
    }

}