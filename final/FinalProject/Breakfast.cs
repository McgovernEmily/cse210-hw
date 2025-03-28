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

        if (Console.ReadLine().ToUpper() == "YES")
        {
            Console.WriteLine("How many did you eat?");
            _protein += int.Parse(Console.ReadLine()) * 6;

        }

        // If user did not have eggs if ask for protein intake.
        else if (Console.ReadLine().ToUpper() == "NO")
        {
            Console.WriteLine("Enter amount of protein you ate for Breakfast (grams)?");
            _protein += int.Parse(Console.ReadLine());
        }

    }

}