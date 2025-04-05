public class Dinner : Meal
{

    // Constructor.
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

            // If user input is not a double, then it will ask again for correct input.
            while (!double.TryParse(Console.ReadLine(), out chicken))
            {
                Console.Write("Not correct. How many pounds of chicken did you eat? ");
            }

            // Calculating the protein of chicken and adding it to protein.
            _protein += chicken * 120;
        }

        // Add another else if for beef.
        else if (userInput.ToUpper() == "B")
        {
            Console.WriteLine("How many pounds of beef did you eat? ");
            double beef;

            // If the user input is not a double, then it will ask again for correct input.
            while (!double.TryParse(Console.ReadLine(), out beef))
            {
                Console.Write("Not correct. Amount of pounds of beef you ate?  ");
            }

            // Calculating the amount of protein for beef and adding it.
            _protein += beef * 77.88;
        }


        // If the user did not have chicken or beef.
        else if (userInput.ToUpper() == "NO")
        {
            Console.WriteLine("Enter amount of protein you eat for Dinner (grams)? ");
            double dGrams;

            // If the user input is not a double, then it will ask again for the correct input.
            while (!double.TryParse(Console.ReadLine(), out dGrams))
            {
                Console.Write("Not correct. Amount of protein had for Dinner (grams)? ");
            }

            // Adding dinner to protein.
            _protein += dGrams;
        }
    }
}