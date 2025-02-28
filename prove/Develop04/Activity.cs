public class Activity
{
    private int _duration; // The duration of the activity.
    private List<string> _animation;

    // Is the constructor for the class. 
    public Activity(int duration)
    {
        _duration = duration;
        _animation = new List<string>
        {
            "|", "/", "-", "\\", "|", "/", "-", "\\"
        };
    }

    // Set for the duration.
    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    // The Get for the duration time. 
    public int GetDuration()
    {
        return _duration;
    }

    // The pause that happens with the animation.
    public void Pause(int time)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(time);

        int i = 0;

        // Does the animation in the allotted time.
        while (DateTime.Now < endTime)
        {
            string s = _animation[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            // If the list is less than the index, then it will result to 0.
            if (i >= _animation.Count)
            {
                i = 0;
            }
        }

    }

    // The count down sequence with numbers.
    public void CountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);  // Print the number
            Thread.Sleep(1000);  // Wait for 1 second
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    // How all the activities start.
    public void StartActivity(string name, string description)
    {
        Console.WriteLine($"Welcome to {name}");
        Console.WriteLine();
        Console.WriteLine(description);
        Console.WriteLine();
        Console.Write("Enter the duration you want:");
        int duration = int.Parse(Console.ReadLine());
        SetDuration(duration);
        Console.WriteLine("Starting Activity...");
        Pause(5);
        Console.WriteLine();
    }

    // How all the activities end. 
    public void EndActivity()
    {
        Console.WriteLine("You have completed the activity!");
        Console.WriteLine($"Time was: {_duration} seconds.");
        Pause(5);
    }

}