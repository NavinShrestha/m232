
public class WortBewertung
{
    // Punkte für ein Wort berechnen
    public static int CalculatePoints(string word)
    {
        return word.ToLower().Count(c => c != 'a' && Char.IsLetter(c));
    }

    // Wörter sortieren nach Punkten (absteigend)
    public static List<(string Word, int Points)> SortWordsByPoints(List<string> words)
    {
        return words
            .Select(word => (Word: word, Points: CalculatePoints(word)))
            .OrderByDescending(entry => entry.Points)
            .ToList();
    }

    public static void Main()
    {
        var wordList = new List<string>();
        string input;

        Console.WriteLine("Wort-Punkte-Rechner");
        Console.WriteLine("Geben Sie Wörter ein (mit 'fertig' beenden): ");

        // Eingabe
        do
        {
            Console.Write("Wort: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && input.ToLower() != "-")
            {
                wordList.Add(input);
            }
        } while (input.ToLower() != "-");

        // Auswertung / Sortierung
        var sortedWords = SortWordsByPoints(wordList);

        Console.WriteLine("Wörter sortiert nach Punkten:");
        foreach (var (word, points) in sortedWords)
        {
            Console.WriteLine($"{word} → {points} Punkte");
        }

        Console.WriteLine("Bewertung abgeschlossen.");
    }
}
