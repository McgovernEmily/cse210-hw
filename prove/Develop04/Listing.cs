using System.Runtime.CompilerServices;

public class Listing : Activity
{
    private List<string> _prompt;

    public Listing(int duration) : base(duration)
    {
        // Creating the list of many different prompts to use.
        _prompt = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    // Uses StartActivity from Activity class to introduce the activity.
    public void StartingActivity()
    {
        StartActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    // Finds and chooses a random prompts from the prompt list.
    public string RandomPrompt()
    {
        Random random = new Random();
        int choice = random.Next(_prompt.Count);
        return _prompt[choice];
    }

    // The entire place the runs the Listing Activity.
    public void RunListing()
    {
        int counting = 0;
        int totalTime = GetDuration();

        string prompt = RandomPrompt();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"---- {prompt} -----");

        Console.Write("You may begin in:");
        CountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(totalTime);

        // Having the user write multiple things in the allotted time.
        while (DateTime.Now < endTime)
        {
            Console.Write(">");
            Console.ReadLine();

            counting += 1;
        }

        Console.WriteLine();
        Console.WriteLine($"You have written {counting} things");
        Console.WriteLine();
        EndActivity();
    }
}