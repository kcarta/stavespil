// TODO: Consider removing the word filtering as this can be done by restricting the letters the player can use and checking against those.
namespace Stavespil;
public class Program
{
    public static async Task Main(string[] args)
    {
        var keepGenerating = true;

        while (keepGenerating)
        {
            var randomLetters = GameBuilder.BuildRandomSetOfLetters(7);
            var words = await GameBuilder.ReadWordListAsync("assets/ord.txt");
            var filteredWords = GameBuilder.FilterWords(words, randomLetters);
            var specialLetter = randomLetters.First();
            filteredWords = filteredWords.Where(word => word.Contains(specialLetter)).ToList();

            if (filteredWords.Count() > 20)
            {
                var game = new GameUI(randomLetters, specialLetter, filteredWords);
                game.PlayGame();
            }
        }
        //Console.WriteLine(randomLetters.Aggregate("", (word, letter) => word + letter));
        //filteredWords.ForEach(Console.WriteLine);
    }
}