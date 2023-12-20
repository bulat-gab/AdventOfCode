using System.Numerics;

namespace AdventOfCode2023.Day10;
public class Solution
{
    private readonly string[] Lines;

    private readonly Complex[] Directions = [Up, Down, Left, Right];

    private static readonly Complex Up = -Complex.One;
    private static readonly Complex Down = Complex.One;
    private static readonly Complex Left = -Complex.ImaginaryOne;
    private static readonly Complex Right = Complex.ImaginaryOne;

    private readonly int RowsNumber;
    private readonly int ColsNumber;

    private readonly Dictionary<Complex, char> _map;

    private readonly Dictionary<char, Complex[]> Rules = new Dictionary<char, Complex[]>
    {
        {'7', [Left, Down] },
        {'F', [Right, Down]},

        {'L', [Up, Right]},
        {'J', [Up, Left]},

        {'|', [Up, Down]},
        {'-', [Left, Right]},

        {'S', [Up, Down, Left, Right]},
        {'.', []},
    };
    
    public Solution(string? filePath = "./Day10/input.txt")
    {
        Lines = File.ReadAllLines(filePath!);
        RowsNumber = Lines.Length;
        ColsNumber = Lines[0].Length;

        _map = ParseMap(Lines);
    }


    public int PartOne()
    {
        var current = _map.First(x => x.Value == 'S').Key;

        var loop = new HashSet<Complex>();

        var dir = Directions.First(dir => Rules[_map[current + dir]].Contains(-dir));

        while (true)
        {
            loop.Add(current);
            current += dir;

            if (_map[current] == 'S')
            {
                break;
            }

            // Pick next dir such that connection exists and new dir != -(old dir) so we don't go back
            var waysToGetHere = Rules[_map[current]];


            dir = waysToGetHere.Single(x => x != -dir);
        }

        //PrintMap(loop);

        return loop.Count / 2;

    }

    private bool IsConnected(Complex to, Complex dir)
    {
        char pipe = _map[to];
        return Rules[pipe].Contains(dir);
    }

    private Dictionary<Complex, char> ParseMap(string[] lines)
    {
        var n = Lines.Length;
        var m = Lines[0].Length;

        var map = new Dictionary<Complex, char>();

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                var complex = new Complex(row, col);
                map[complex] = lines[row][col];

            }
        }

        if (!map.Values.Contains('S'))
        {
            throw new NotImplementedException("S cell not found.");
        }

        return map;
    }

    void PrintMap(HashSet<Complex>? loop = null)
    {
        var n = Lines.Length;
        var m = Lines[0].Length;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                var complex = new Complex(row, col);

                var ch = _map[complex];
                
                if (loop != null)
                {
                    if (loop.Contains(complex))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }

                Console.Write(ch);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
