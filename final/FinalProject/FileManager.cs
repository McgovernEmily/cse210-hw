using System.IO;

public class FileManager
{
    private string _fileName;

    public FileManager(string fileName)
    {
        _fileName = fileName;
    }

    // Saving the info to a file.
    public void SaveToFile(UserStorage userStorage, MealTracker mealTracker)
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            foreach (var user in userStorage.GetAllUsers())
            {
                outputFile.WriteLine($"User | {user.GetName()} | {user.GetWeight()} | {user.GetProteinGoal()}");
            }

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
                    string name = parts[1];
                    double weight = double.Parse(parts[2]);
                    double proteinGoal = double.Parse(parts[3]);
                    userStorage.AddUser(name, weight, "", 0, proteinGoal);
                }
                else if (parts[0] == "Meal")
                {
                    string mealtype = parts[1];
                    double protein = double.Parse(parts[2]);

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
                        meal.SetProtein(protein);
                        mealTracker.GetMeals().Add(meal);
                    }
                }
            }
            Console.WriteLine("Protein intake loaded!");
        }
    }

    public bool FindingUserFile(string userName)
    {
        if (!File.Exists(_fileName))
        {
            return false;
        }

        using (StreamReader read = new StreamReader(_fileName))
        {
            string line;
            while ((line = read.ReadLine()) != null)
            {
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