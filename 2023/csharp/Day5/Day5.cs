namespace AdventOfCode.Day5;
public class Day5
{
    private int[] TrimAndSplitStringToIntArray(string input)
    {
        return input.Trim()
            .Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(int.Parse)
            .ToArray();
    }


    public int PartOne()
    {
        var lines = File.ReadAllLines("./Day5/input.txt");

        int score = 0;
        foreach (var line in lines)
        {

        }
        Console.WriteLine(score);
        return score;

    }

    public int PartTwo()
    {
        return 0;
    }
}
