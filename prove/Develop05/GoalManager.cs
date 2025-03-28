using System.IO;
using Microsoft.VisualBasic;

public class GoalManager
{
    private List<Goals> _goals;
    private int _score;
    private int _level;
    private int _nextLevelPoints;

    public GoalManager(int score)
    {
        _goals = new List<Goals>();
        _score = score;
        _level = 0;
        _nextLevelPoints = 500;
    }

    // How the goal is created.
    public Goals CreateGoal()
    {
        // The user will select which goal they would like to do.
        Console.WriteLine("Select goal type: 1. Regular 2. Eternal 3. Checklist");
        Console.Write(">");
        string choice = Console.ReadLine();

        // The user will name the goal.
        Console.WriteLine("Enter goal name:");
        Console.Write(">");
        string name = Console.ReadLine();

        // The user describes the goal.
        Console.WriteLine("Enter description: ");
        Console.Write(">");
        string description = Console.ReadLine();

        // The user will list the points associated with the goal.
        Console.WriteLine("Enter points: ");
        Console.Write(">");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            // If it is regular goal then it will create a regular goal.
            case "1":
                return new RegularGoals(name, description, points);

            // If the goal is eternal then it will call the eternal goal.
            case "2":
                return new EternalGoals(name, description, points);

            // If the goal is checklist then it will call the check list class.
            case "3":

                // The user will number how many times to complete.
                Console.WriteLine("Enter the total times it needs to be completed: ");
                Console.Write(">");
                int totalTimes = int.Parse(Console.ReadLine());

                // The user will enter the bonus points associated with the goal.
                Console.WriteLine("Enter the bonus points for when completed: ");
                Console.Write(">");
                int bonusPoints = int.Parse(Console.ReadLine());

                return new CheckListGoals(name, description, points, totalTimes, 0, bonusPoints);

            // If they choose a different number than 1, 2, 3 then it will show incorrect.
            default:
                Console.WriteLine("Incorrect, Choose something different.");
                return null;
        }

    }

    // Adds the goals created to the list.
    public void AddGoal(Goals goal)
    {
        _goals.Add(goal);
    }

    // Lists the goals.
    public void ListGoals()
    {
        // For each goal in the list, it will display it.
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{goal.Status()} {goal.GetName()} - {goal.GetDescription()} - {goal.GetPoints()} points");
        }
    }

    // Displaying the points and level.
    public void DisplayScore()
    {
        Console.WriteLine($"Points: {_score} | Level: {_level}");
    }

    // Completing the goal.
    public void CompleteGoal()
    {
        Console.WriteLine("Select the goal you completed:");

        // Display all the goals in the list.
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        // The user chooses the goal.
        Console.WriteLine();
        Console.WriteLine("Enter the number for the goal you completed: ");
        Console.Write(">");
        int index = int.Parse(Console.ReadLine());

        // Will find the goal and then add the points to the score.
        Goals goalToComplete = _goals[index - 1];
        int points = goalToComplete.Record();
        _score += points;

        // Display the goal that was completed and how many points were earned.
        Console.WriteLine();
        Console.WriteLine($"Goal {goalToComplete.GetName()} is completed! You earned {points} points.");

    }

    // Checking the level the user is at.
    public void CheckLevel()
    {

        // If the level is above the nextLevelPoints then the user levels up.
        if (_score >= _nextLevelPoints)
        {
            _level++;
            _nextLevelPoints += 1000;
            Console.WriteLine();
            Console.WriteLine($"YOU LEVELED UP!!! You are now level {_level}");
        }
    }

    // Saving goals to a file.
    public void SaveToFile()
    {
        // The user will state a file name they wish to save goals in.
        Console.WriteLine("File name: ");
        Console.Write(">");
        string fileName = Console.ReadLine();

        // Writing the goals to the file the users wanted.
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {

            outputFile.WriteLine($"Points | {_score}");
            outputFile.WriteLine($"Level | {_level}");
            outputFile.WriteLine($"NextLevelPoints | {_nextLevelPoints}");

            // For each goal in goal list, it will state if it's regular, eternal or checklist.
            foreach (var goal in _goals)
            {
                string typeGoal = goal is RegularGoals ? "Regular" : goal is EternalGoals ? "Eternal" : goal is CheckListGoals ? "Checklist" : "Unknown";
                if (goal is CheckListGoals checklistGoal)
                {
                    outputFile.WriteLine($"{typeGoal} | {goal.GetName()} | {goal.GetDescription()} | {goal.GetPoints()} | {checklistGoal.Status()} | {checklistGoal.GetBonusPoints()}");
                }
                else
                {
                    outputFile.WriteLine($"{typeGoal} | {goal.GetName()} | {goal.GetDescription()} | {goal.GetPoints()} | {goal.Status()}");
                }
            }
        }

        Console.WriteLine("Goals are saved!");
    }

    // Loading all goals from the file.
    public void LoadFromFile()
    {
        // The user will type a file they want to import goals from.
        Console.WriteLine("File name: ");
        Console.Write(">");
        string fileName = Console.ReadLine();

        // It will read from the file and then have it in the program.
        using (StreamReader reader = new StreamReader(fileName))
        {

            // Reading the score, level, and nextlevelpoints to the program.
            _score = int.Parse(reader.ReadLine().Split(" | ")[1]);
            _level = int.Parse(reader.ReadLine().Split(" | ")[1]);
            _nextLevelPoints = int.Parse(reader.ReadLine().Split(" | ")[1]);

            string storeGoal;
            while ((storeGoal = reader.ReadLine()) != null)
            {
                var parts = storeGoal.Split(" | ");

                // Finding all data in the file and splitting it by index.
                string dataType = parts[0];
                string dataName = parts[1];
                string dataDescription = parts[2];
                int dataPoints = int.Parse(parts[3]);

                Goals goal = null;

                // If the data type is regular, then it will add the goal as a regular goal.
                if (dataType == "Regular")
                {
                    goal = new RegularGoals(dataName, dataDescription, dataPoints);
                    _goals.Add(goal);
                }

                // If the data type is eternal, then it will be added as an eternal goal.
                else if (dataType == "Eternal")
                {
                    goal = new EternalGoals(dataName, dataDescription, dataPoints);
                    _goals.Add(goal);
                }

                // If the data type is checklist, then is will be added as a checklist goal.
                else if (dataType == "Checklist")
                {
                    int targetCount = int.Parse(parts[4].Split("/")[1].Trim(']'));
                    int currentCount = int.Parse(parts[4].Split("/")[0].Trim('['));
                    int bonusPoints = int.Parse(parts[5]);
                    goal = new CheckListGoals(dataName, dataDescription, dataPoints, targetCount, currentCount, bonusPoints);
                    _goals.Add(goal);
                }

            }
        }

        // If there was nothing in the file, then is will not upload.
        if (_goals.Count == 0)
        {
            Console.WriteLine("File was not uploaded.");
        }
        else
        {
            Console.WriteLine("You have successfully uploaded from the file.");
        }

    }
}