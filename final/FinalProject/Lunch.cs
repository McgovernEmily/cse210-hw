public class Lunch : Meal
{
    public Lunch() : base("Lunch", 0)
    {

    }

    // Protein intake for lunch. Want to add something special to this one. 
    public override void EnterMealDetails()
    {
        Console.WriteLine("Enter amount of protein you ate for lunch (grams)?");
        _protein += int.Parse(Console.ReadLine());
    }
}