using System.ComponentModel.DataAnnotations;

namespace PlayerRankings;
class Program
{
    static void Main()
    {
        var SortedScores = new SortedDictionary<int, string>();
        SortedScores.Add(40, "Alice");
        SortedScores.Add(93, "Bob");
        SortedScores.Add(30, "Charlie");
        SortedScores.Add(56, "David");
        SortedScores.Add(14, "Elise");
        SortedScores.Add(28, "Fred");
        SortedScores.Add(15, "Greg");
        SortedScores.Add(29, "Helen");
        SortedScores.Add(100, "Imogen");
        SortedScores.Add(54, "John");

        var Top3Scores = SortedScores.OrderByDescending(x => x.Key).Take(3);
        var Bottom3Scores = SortedScores.OrderBy(x => x.Key).Take(3);

        Console.WriteLine("Top 3:");
        foreach (var entry in Top3Scores)
        {
            Console.WriteLine($"{entry.Value} scored {entry.Key} points.");
        }

        Console.WriteLine("Bottom 3:");
        foreach (var entry in Bottom3Scores)
        {
            Console.WriteLine($"{entry.Value} scored {entry.Key} points.");
        }

        SortedScores.Remove(54);
        Console.WriteLine("John left the game. Remaining players are:");
        foreach (var entry in SortedScores)
        {
            Console.WriteLine($"{entry.Value} with {entry.Key} points.");
        }

        SortedScores.Add(100, "James");
        SortedScores.Add(1, "Alice");
    }
}