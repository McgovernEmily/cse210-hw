using System;
using System.Security.AccessControl;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when you are done.");

        int UserInt;
        do
        {
            Console.Write("Enter a number: ");
            string UserNum = Console.ReadLine();
            UserInt = int.Parse(UserNum);

            if (UserInt != 0)
            {
                numbers.Add(UserInt);
            }

        } while (UserInt != 0);

        int Total = numbers.Sum();
        Console.WriteLine($"The sum is: {Total}");

        double Average = numbers.Average();
        Console.WriteLine($"The average is: {Average}");

        int MaxNum = numbers.Max();
        Console.WriteLine($"The largest number is: {MaxNum}");

    }
}