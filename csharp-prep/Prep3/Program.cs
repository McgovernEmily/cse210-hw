using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int MagicNum = randomGenerator.Next(1, 100);

        int AmountGuess = 0;
        int Guess;
        do
        {
            Console.Write("Guess the magic number: ");
            string GuessUser = Console.ReadLine();
            Guess = int.Parse(GuessUser);

            AmountGuess++;

            if (MagicNum > Guess)
            {
                Console.WriteLine("You are too low");

            }
            else if (MagicNum < Guess)
            {
                Console.WriteLine("You are too high");

            }
        } while (Guess != MagicNum);

        Console.WriteLine("You got it");
        Console.WriteLine($"You guessed: {AmountGuess} ");

    }
}