public class Dinner : Meal
{
    public Dinner() : base("Dinner", 20)
    {

    }

    // Protein intake for dinner.
    public override void EnterMealDetails()
    {

        // Asking user if they had chicken.
        Console.WriteLine("Did you eat chicken for Dinner (YES or NO)?");

        if (Console.ReadLine().ToUpper() == "YES")
        {
            Console.WriteLine("How much in grams did you eat? ");
            _protein += int.Parse(Console.ReadLine()) * 0.27;

        }

        // Add another else if for beef.


        // If the user did not have chicken or beef.
        else if (Console.ReadLine() == "No" | Console.ReadLine() == "no")
        {
            Console.WriteLine("Enter amount of protein you eat for Dinner (grams)? ");
            _protein += int.Parse(Console.ReadLine());
        }
    }
}