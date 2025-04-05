using System.Diagnostics.Contracts;

public class MealTracker
{
    private List<Meal> _meals;

    // Constructor.
    public MealTracker()
    {
        _meals = new List<Meal>();
    }

    // Adding a meal to the list.
    public void AddMeals()
    {

        // Asking user what type of meal they would like to input protein for.
        Console.WriteLine("Please Enter meal type (Breakfast, Lunch, Dinner, Snack): ");
        string mealtype = Console.ReadLine().ToLower();
        Meal meal = null;

        // Choosing what the user stated.
        switch (mealtype)
        {
            case "breakfast":
                meal = new Breakfast();
                break;

            case "lunch":
                meal = new Lunch();
                break;

            case "dinner":
                meal = new Dinner();
                break;

            case "snack":
                meal = new Snack();
                break;
        }

        // Adding the meal to the list.
        meal.EnterMealDetails();
        _meals.Add(meal);
    }

    public List<Meal> GetMeals()
    {
        return _meals;
    }

    public void ClearMeal()
    {
        _meals.Clear();
    }
}