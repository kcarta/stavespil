namespace Stavespil;

public class GameBuilder
{
    public const string ALPHABET = "abcdefghijklmnopqrstuvwxyzæåø";

    public static void BuildGame()
    {

    }

    public static string BuildRandomSetOfLetters(int desiredLength)
    {
        if (desiredLength <= 0 || desiredLength >= 10) throw new ArgumentOutOfRangeException("Desired length must be positive and below 10");
        return BuildRandomSetOfLetters(ALPHABET, "", desiredLength);
    }

    private static string BuildRandomSetOfLetters(string remainingLetters, string currentList, int limit)
    {
        if (currentList.Count() == limit)
        {
            return currentList;
        }
        else
        {
            var random = new Random();
            var randomNumber = random.Next(remainingLetters.Count());
            var randomLetter = remainingLetters[randomNumber].ToString();
            return BuildRandomSetOfLetters(remainingLetters.Replace(randomLetter, string.Empty), currentList + randomLetter, limit);
        }
    }


    public static async Task<List<string>> ReadWordListAsync(string filePath)
    {
        var lines = await File.ReadAllLinesAsync(filePath, System.Text.Encoding.UTF8);
        return new HashSet<string>(lines).ToList();
    }

    public static List<string> FilterWords(List<string> words, string randomLetters)
    {
        return words
            .Where(word => word.Length >= 3)
            .Where(word => word.Distinct().All(letter => randomLetters.Contains(letter)))
            .ToList();
    }
}