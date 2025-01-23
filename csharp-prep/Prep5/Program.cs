using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string UserName = PromptUserName();

        int FavNum = PromptUserNumber();

        int SquareNum = SquareNumber(FavNum);

        DisplayResult(UserName, SquareNum);

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string UserName = Console.ReadLine();

            return UserName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int Num = int.Parse(Console.ReadLine());

            return Num;

        }

        static int SquareNumber(int SquareNum)
        {
            int TotalSquare = SquareNum * SquareNum;
            return TotalSquare;
        }

        static void DisplayResult(string UserName, int TotalSquare)
        {
            Console.WriteLine($"{UserName}, the square of your number is {TotalSquare}");
        }

    }
}