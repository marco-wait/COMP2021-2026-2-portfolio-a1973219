namespace AdventDay7;

using System.IO.Pipelines;
using System.Text;
/// <summary>
/// Class <c>Program</c> contains the magical tachyon manifold.
/// </summary>
public static class Program
{

    // String points to file on PC containing relevant input.
    public static string FileToRead { get; set; } = "C:/Users/marco/Documents/software-development-practice/Week4/PracB/TachyonManifold/Example.txt";

    /// <summary>
    /// This method processes the start of the tachyon manifold.
    /// <example>
    /// For example:
    /// <code>
    /// ProcessStart(0, 0, tachyonGrid);
    /// </code>
    /// results in <c>'|'</c>being added to the grid point (0,1)
    /// </example>
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="tachyonGrid"></param>
    public static void processStart(int posX, int posY, List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY + 1];
        StringBuilder sb = new StringBuilder(line);
        sb[posX] = '|';
        line = sb.ToString();
        tachyonGrid[posY + 1] = line;
    }

    /// <summary>
    /// If the space above the given position in the grid contains a beam, simulates splitting the beam to either side.
    /// </summary>
    /// <returns>
    /// 1 if a split took place, otherwise 0.
    /// </returns>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="tachyonGrid"></param>
    public static int processSplitter(int posX, int posY, List<string> tachyonGrid)
    {
        int count = 0;
        string line = tachyonGrid[posY];
        StringBuilder sb = new StringBuilder(line);
        if (tachyonGrid[posY - 1][posX] == '|')
        {
            sb[posX - 1] = '|';
            sb[posX + 1] = '|';
            line = sb.ToString();
            tachyonGrid[posY] = line;
            count = 1;
        }
        return count;
    }

    /// <summary>
    /// If the space above the given position in the grid contains a beam, adds a new segment to that beam.
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    /// <param name="tachyonGrid"></param>
    public static void processEmpty(int posX, int posY, List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY];
        StringBuilder sb = new StringBuilder(line);
        if (tachyonGrid[posY - 1][posX] == '|')
        {
            sb[posX] = '|';
            line = sb.ToString();
            tachyonGrid[posY] = line;
        }
    }

    public static void Main(string[] args)
    {
        var sr = new StreamReader(FileToRead);
        string srText = sr.ReadToEnd();
        int totalCount = 0;

        List<string> symbols = [.. srText.Split("\n")];
        List<string> tachyonGrid = symbols[..^1];

        Console.WriteLine("Begin Tachyon Manifold start state");
        foreach (var item in tachyonGrid)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("End Tachyon Manifold start state");

        for (int posY = 0; posY < tachyonGrid.Count; posY++)
        {
            var item = tachyonGrid[posY];
            foreach (var (posX, character) in item.Index())
            {
                if (character == 'S')
                {
                    processStart(posX, posY, tachyonGrid);
                }
                else if (character == '^')
                {
                    totalCount += processSplitter(posX, posY, tachyonGrid);
                }
                else if (posY != 0)
                {
                    processEmpty(posX, posY, tachyonGrid);
                }
            }
        }
        Console.WriteLine($"Begin Taychon Manifold end state");

        foreach (var item in tachyonGrid)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"End Taychon Manifold end state");
        Console.WriteLine($"Total Tachyon Manifold splits were: {totalCount}");
        Console.WriteLine($"If using Example.txt, your total should be 21");
        Console.WriteLine($"If using Example.txt, your total is {(totalCount == 21 ? "RIGHT": "WRONG")}");
    }
}
