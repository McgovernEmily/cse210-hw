using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

public class Snack : Meal
{
    public Snack() : base("Snack", 0)
    {

    }

    public override void EnterMealDetails()
    {
        // Protein intake from a Snack.
        Console.WriteLine("Enter protein content for the Snack (grams)? ");
        double tooMuch;
        while (!double.TryParse(Console.ReadLine(), out tooMuch))
        {
            Console.Write("Not correct. protein content for Snack (grams)? ");
        }

        // Adding it to the total protein.
        _protein += tooMuch;

        // Want to keep protein to below 30 grams. Gives a warning to try and stay below.
        if (tooMuch >= 30)
        {
            Console.WriteLine("That's too much for just a snack, try eating less for snack and more for meals");
        }
        else
        {
            Console.WriteLine("Good job for eating less than 30 gram of protein for snack.");
        }
    }
}