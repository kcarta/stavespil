using System;

namespace Stavespil;

public class GameUI
{
    private readonly List<string> guessedWords = new List<string>();
    private readonly List<string> unguessedWords;
    private readonly string letters;
    private readonly char specialLetter;


    public GameUI(string letters, char specialLetter, List<string> validWords)
    {
        this.letters = letters;
        this.specialLetter = specialLetter;
        this.unguessedWords = new List<string>(validWords);
    }

    public void PlayGame()
    {
        while (true)
        {
            ShowGameState();
            var playerGuess = GetPlayerGuess();
            EvaluatePlayerGuess(playerGuess);
        }
    }

    private void EvaluatePlayerGuess(string playerGuess)
    {
        if(playerGuess.Equals("k")) {
            unguessedWords.ForEach(Console.WriteLine);

        }
        if (!playerGuess.Contains(specialLetter))
        {
            Console.WriteLine("===========================");
            Console.WriteLine("You must use the special letter: " + specialLetter);
            Console.WriteLine("===========================");
        }
        else
        {
            var result = unguessedWords.Find(word => word.Equals(playerGuess));
            Console.WriteLine("===========================");

            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("*** Your guess came up empty, try again!");
            }
            else
            {
                Console.WriteLine("*** Success!");
                unguessedWords.Remove(result);
                guessedWords.Add(result);
            }
            Console.WriteLine("===========================");
        }
    }

    private string GetPlayerGuess()
    {
        Console.WriteLine("===========================");
        Console.WriteLine("*** Enter your guess:");
        var playerGuess = Console.ReadLine();
        Console.WriteLine("===========================");
        if (!string.IsNullOrWhiteSpace(playerGuess))
        {
            return playerGuess;

        }
        else
        {
            return GetPlayerGuess();
        }
    }

    private void ShowGameState()
    {
        Console.WriteLine("===========================");
        Console.WriteLine("Your letters are: " + letters);
        Console.WriteLine("---------------------------");
        Console.WriteLine("The special letter is: " + specialLetter);
        Console.WriteLine("---------------------------");
        Console.WriteLine("There are: " + unguessedWords.Count() + " valid words remaining");
        Console.WriteLine("---------------------------");
        Console.WriteLine("You have guessed: " + guessedWords.Aggregate("", (agg, next) => next + ", " + agg));
        Console.WriteLine("---------------------------");
        Console.WriteLine("===========================");
    }


}