namespace AdventOfCode2023.Day3;
public class Solution
{
    private const string Numbers = "0123456789";
    private const string Symbols = "%/-*$&+#=@";

    private readonly string[] Lines;

    private readonly int Width;

    private readonly HashSet<Number> Visited = [];

    private readonly (int, int)[] Directions =
    [
        (-1, -1),
        (-1,  0),
        (-1,  1),
        ( 0, -1),
        ( 0,  1),
        ( 1, -1),
        ( 1,  0),
        ( 1,  1),
    ];

    public Solution()
    {
        Lines = File.ReadAllLines("./Day3/input.txt");
        Width = Lines[0].Length;
    }

    public int PartOne()
    {
        return Lines
            .Select((line, row) => 
                line.Select((symbol, col) => new { Symbol = symbol, Col = col })
                    .Where(x => Symbols.Contains(x.Symbol))
                    .Select(x => GetAdjacent(row, x.Col).Sum(x => x.Value))
                    .Sum())
            .Sum();
    }

    /*
    * Gear == symbol * adjacent to exactly 2 numbers
    * Gear ratio  == multiple of those 2 numbers
    * Find sum of all gear ratios
    *
    **/
    public int PartTwo()
    {
        return Lines
            .Select((line, row) =>
                line.Select((symbol, col) => new { Symbol = symbol, Col = col })
                    .Where(x => x.Symbol == '*')
                    .Select(x => GetAdjacent(row, x.Col).ToArray())
                    .Where(x => x.Length == 2)
                    .Select(x => x[0].Value * x[1].Value)
                    .Sum())
            .Sum();
    }

    private IEnumerable<Number> GetAdjacent(int row, int col)
    {
        foreach (var (dx, dy) in Directions)
        {
            var x = dx + col;
            var y = dy + row;

            if (IsValidCoordinate(x, y) && char.IsNumber(Lines[y][x]))
            {
                var number = ParseNumber(x, y);
                if (!Visited.Contains(number))
                {
                    Visited.Add(number);
                    yield return number;
                }
            }
        }
    }

    public Number ParseNumber(int x, int y)
    {
        var line = Lines[y];

        var left = x;
        var right = x;

        while (left > -1 && char.IsNumber(line[left]))
        {
            left--;
        }

        while (right < Width && char.IsNumber(line[right]))
        {
            right++;
        }

        left++;
        var numberString = line[left..right];
        return new Number(int.Parse(numberString), (y, left, right));
    }

    private bool IsValidCoordinate(int dx, int dy)
    {
        return 0 <= dx && dx < Width 
            && 0 <= dy && dy < Lines.Length;
    }

    public record Number(int Value, (int Row, int X, int Y) Coordinate);
}
