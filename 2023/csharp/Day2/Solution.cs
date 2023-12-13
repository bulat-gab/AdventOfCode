using System.Text.RegularExpressions;

namespace AdventOfCode.Day2;
public class Solution
{
    public int PartOne()
    {
        // Example line:
        // Game 1: 2 red, 2 green; 6 red, 3 green; 2 red, 1 green, 2 blue; 1 red"
        var lines = File.ReadAllLines("./Day2/input.txt");

        int sum = 0;
        foreach (var line in lines)
        {
            var (gameId, red, green, blue) = ParseGame(line);

            if (red <= 12 && green <= 13 && blue <= 14)
            {
                sum += gameId;
            }
        }

        return sum;
    }

    public int PartTwo()
    {
        var lines = File.ReadAllLines("./Day2/input.txt");

        int sum = 0;
        foreach (var line in lines)
        {
            var (gameId, red, green, blue) = ParseGame(line);

            sum += red * green * blue;
        }

        return sum;
    }

    private static (int gameId, int red, int green, int blue) ParseGame(string line)
    {
        var gameId = ParseInput(line, @"Game (\d+)").First();

        var red = ParseInput(line, @"(\d+) red").Max();
        var green = ParseInput(line, @"(\d+) green").Max();
        var blue = ParseInput(line, @"(\d+) blue").Max();

        return (gameId, red, green, blue);
    }

    private static IEnumerable<int> ParseInput(string line, string pattern)
    {
        return Regex.Matches(line, pattern)
            .Select(x => x.Groups[1].Value)
            .Select(int.Parse);
    }
}
