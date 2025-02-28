public class Reflection : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    // All the prompts and questions that are in the lists.
    public Reflection(int duration) : base(duration)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was over?",
            "What is your favorite thing about this experience?",
            "What could you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "What made this time difference than other times when you were not successful?"
        };
    }

    // How the Activity is introduced to the user.
    public void StartingActivity()
    {
        StartActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    }

    // Finding a random prompt from the prompt list.
    public string RandomPrompt()
    {
        Random random = new Random();
        int choice = random.Next(_prompts.Count);
        return _prompts[choice];
    }

    // Finding a random question from the question list.
    public string RandomQuestion()
    {
        Random random = new Random();
        int choice = random.Next(_questions.Count);
        return _questions[choice];
    }

    // How the whole Activity runs.
    public void RunReflection()
    {
        int time = 0;
        int totalTime = GetDuration();

        string prompt = RandomPrompt();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"---- {prompt} -----");

        Console.WriteLine("Press Enter when you are ready to continue...");
        Console.ReadLine();

        Console.WriteLine("You are now going to answer some questions");
        CountDown(5);

        // Goes through multiple questions until the time is up.
        while (time < totalTime)
        {
            string question = RandomQuestion();

            Console.WriteLine(question);
            Pause(15);

            time += 15;
        }

        Console.WriteLine();
        EndActivity();
    }
}