using System.Drawing;

public class Breakfast : Meal
{

    // Constructor.
    public Breakfast() : base("Breakfast", 0)
    {

    }

    // Protein intake for breakfast.
    public override void EnterMealDetails()
    {

        // Asking user if they had eggs or not.
        Console.WriteLine("Did you eat eggs for Breakfast (YES or NO)?");
        string userInput = Console.ReadLine();

        // If user input yes then it will ask for amount of eggs.
        if (userInput.ToUpper() == "YES")
        {
            Console.Write("How many did you eat? ");
            int eggs;

            // If input is not an int then it will ask again for correct input.
            while (!int.TryParse(Console.ReadLine(), out eggs))
            {
                Console.Write("Not correct. How many eggs did you eat? ");
            }

            // Calculating the protein for eggs.
            _protein += eggs * 6;

        }

        // If user did not have eggs if ask for protein intake.
        else if (userInput.ToUpper() == "NO")
        {
            Console.Write("Enter amount of protein you ate for Breakfast (grams)?");
            double bGrams;

            // If the user input is not a double, then it will ask again for correct input.
            while (!double.TryParse(Console.ReadLine(), out bGrams))
            {
                Console.Write("Not correct. Amount of protein you ate for Breakfast (grams)? ");
            }

            // Adding breakfast to protein.
            _protein += bGrams;
        }

    }

}