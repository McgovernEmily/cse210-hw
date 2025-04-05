public class Lunch : Meal
{

    // Constructor.
    public Lunch() : base("Lunch", 0)
    {

    }

    // Protein intake for lunch.
    public override void EnterMealDetails()
    {
        Console.WriteLine("Enter amount of protein you ate for Lunch (grams)?");
        double lGrams;

        // If input is not a double, then it will ask again for correct input.
        while (!double.TryParse(Console.ReadLine(), out lGrams))
        {
            Console.Write("Not correct. Amount of protein you ate for Lunch (grams)? ");
        }

        // Adding lunch to the protein.
        _protein += lGrams;
    }
}