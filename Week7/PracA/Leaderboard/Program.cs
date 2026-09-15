namespace Leaderboard;

public static class Program
{
    public static void DisplayScores(SortedSet<int> scores)
    {
        Console.WriteLine("Here are the scores:");
        foreach (int score in scores)
        {
            Console.WriteLine(score);
        }

        Console.WriteLine($"Highest: {scores.Max}");
        Console.WriteLine($"Lowest: {scores.Min}");
    }

    public static void Main(string[] args)
    {
        SortedSet<int> scores = [40, 93, 30, 56, 14, 28, 15, 29, 100, 54];
        DisplayScores(scores);

        scores.Add(1); // add new lowest score
        DisplayScores(scores);

        scores.Add(100); // add duplicate score
        DisplayScores(scores);
    }
}
