public class Lunch : Meal
{
    public Lunch() : base("Lunch", 0)
    {

    }

    // Protein intake for lunch.
    public override void EnterMealDetails()
    {
        Console.WriteLine("Enter amount of protein you ate for Lunch (grams)?");
        double lGrams;
        while (!double.TryParse(Console.ReadLine(), out lGrams))
        {
            Console.Write("Not correct. Amount of protein you ate for Lunch (grams)? ");
        }
        _protein += lGrams;
    }
}