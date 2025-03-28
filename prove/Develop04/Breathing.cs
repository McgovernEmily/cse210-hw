using System;
using System.Diagnostics;
public class Breathing : Activity
{
    public Breathing(int duration) : base(duration)
    {

    }

    // How the Activity is started and introduced to the user. 
    public void StartingActivity()
    {
        StartActivity("Breathing Exercise", "This activity will help you relax by guiding you through slow breathing. Focus on your breath.");
    }

    // How the Activity runs.
    public void RunningBreath()
    {

        int timeForBreathe = 9;
        int totalTime = GetDuration() / timeForBreathe;

        // Goes through the amount of time and states when to breath in and out.
        for (int i = 0; i < totalTime; i++)
        {
            Console.WriteLine();
            Console.Write($"Breathe in....");
            CountDown(4);
            Console.Write($"Breathe out...");
            CountDown(5);
            Console.WriteLine();
        }

        EndActivity();
    }

}
