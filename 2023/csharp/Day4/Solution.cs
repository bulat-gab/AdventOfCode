using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day4;
public class Solution
{
    public int PartOne()
    {
        var lines = File.ReadAllLines("./Day4/input.txt");

        return lines
            .Select(GetNumberOfMatches)
            .Select(matches => (int)Math.Pow(2, matches - 1))
            .Sum();
    }

    public int PartTwo()
    {
        var lines = File.ReadAllLines("./Day4/input.txt");

        int[] counts = Enumerable.Repeat(1, lines.Length).ToArray();

        for (int i = 0; i < lines.Length; i++)
        {
            var matches = GetNumberOfMatches(lines[i]);

            var numberOfCopies = counts[i];

            // add winning copy
            while (matches > 0)
            {
                if (matches + i < counts.Length)
                {
                    counts[i + matches] = counts[i + matches] + numberOfCopies;
                }
                matches--;
            }
        }

        return counts.Sum();
    }

    private static int GetNumberOfMatches(string line)
    {
        var parts = line.Split(':', '|');
        var winningCards = ParseCards(parts[1]);
        var myCards = ParseCards(parts[2]);

        return winningCards
            .Intersect(myCards)
            .Count();
    }

    private static IEnumerable<string> ParseCards(string cards)
        => Regex.Matches(cards, @"\d+").Select(x => x.Value);
}
