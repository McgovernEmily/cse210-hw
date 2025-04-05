using System.Drawing;

public class Breakfast : Meal
{

    public Breakfast() : base("Breakfast", 0)
    {

    }

    // Protein intake for breakfast.
    public override void EnterMealDetails()
    {

        // Asking user if they had eggs or not.
        Console.WriteLine("Did you eat eggs for Breakfast (YES or NO)?");
        string userInput = Console.ReadLine();

        if (userInput.ToUpper() == "YES")
        {
            Console.Write("How many did you eat? ");
            int eggs;
            while (!int.TryParse(Console.ReadLine(), out eggs))
            {
                Console.Write("Not correct. How many eggs did you eat? ");
            }
            _protein += eggs * 6;

        }

        // If user did not have eggs if ask for protein intake.
        else if (userInput.ToUpper() == "NO")
        {
            Console.Write("Enter amount of protein you ate for Breakfast (grams)?");
            double bGrams;
            while (!double.TryParse(Console.ReadLine(), out bGrams))
            {
                Console.Write("Not correct. Amount of protein you ate for Breakfast (grams)? ");
            }
            _protein += bGrams;
        }

    }

}