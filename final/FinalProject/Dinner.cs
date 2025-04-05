public class Dinner : Meal
{
    public Dinner() : base("Dinner", 20)
    {

    }

    // Protein intake for dinner.
    public override void EnterMealDetails()
    {

        // Asking user if they had chicken.
        Console.WriteLine("Did you eat chicken or beef for Dinner (C = Chicken, B = Beef, No = Not eat neither)?");
        string userInput = Console.ReadLine();

        if (userInput.ToUpper() == "C")
        {
            Console.WriteLine("How many pounds of chicken did you eat? ");
            double chicken;
            while (!double.TryParse(Console.ReadLine(), out chicken))
            {
                Console.Write("Not correct. How many pounds of chicken did you eat? ");

            }
            _protein += chicken * 120;

        }

        // Add another else if for beef.
        else if (userInput.ToUpper() == "B")
        {
            Console.WriteLine("How many pounds of beef did you eat? ");
            double beef;
            while (!double.TryParse(Console.ReadLine(), out beef))
            {
                Console.Write("Not correct. Amount of pounds of beef you ate?  ");
            }
            _protein += beef * 77.88;

        }


        // If the user did not have chicken or beef.
        else if (userInput.ToUpper() == "NO")
        {
            Console.WriteLine("Enter amount of protein you eat for Dinner (grams)? ");
            double dGrams;
            while (!double.TryParse(Console.ReadLine(), out dGrams))
            {
                Console.Write("Not correct. Amount of protein had for Dinner (grams)? ");
            }
            _protein += dGrams;
        }
    }
}