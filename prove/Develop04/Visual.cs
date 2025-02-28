using System.Runtime.InteropServices;

public class Visual : Activity
{
    private List<string> _visualPrompt;

    // All the prompts and questions that are in the lists.
    public Visual(int duration) : base(duration)
    {
        _visualPrompt = new List<string>
        {
            "Envision yourself floating on a serene lake, feeling the gentle rocking of the water.",
            "Visualize sitting by a cozy fireplace, listening to the crackling of the fire.",
            "Imagine yourself on a mountain top, breathing in the fresh, crisp air.",
            "Visualize a sunny field with butterflies fluttering around you.",
            "Picture yourself on a warm, sandy beach, feeling the sun on your skin.",
            "Imagine lying in a hammock under a clear night sky, gazing at the stars."
        };
    }

    // How the Activity is introduced to the user.
    public void StartingActivity()
    {
        StartActivity("Visualize Activity", "This activity will guide you through peaceful visualization to help calm your mind.");
    }

    // Finding a random prompt in the prompt list.
    public string RandomVisual()
    {
        Random random = new Random();
        int choice = random.Next(_visualPrompt.Count);
        return _visualPrompt[choice];
    }

    // Where the Visual Activity runs. 
    public void RunVisual()
    {
        int duration = GetDuration();
        string prompt = RandomVisual();
        Console.WriteLine("Take a deep breath and visualize the prompt:");
        Console.WriteLine($"------{prompt}------");
        Console.WriteLine("Take a slow deep breath and immerse yourself");
        CountDown(5);
        Pause(duration);
        EndActivity();
    }
}