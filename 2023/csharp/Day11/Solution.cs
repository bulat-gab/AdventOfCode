using System.Numerics;

namespace AdventOfCode2023.Day11;
public class Solution
{
    private readonly string[] Lines;

    public Solution()
    {
        Lines = File.ReadAllLines("./Day11/input.txt");
    }

    public long PartOne()
    {
        return Solve(2);
    }

    public long PartTwo()
    {
        return Solve(1000000);
    }

    public long Solve(int multiplier)
    {
        long sum = 0;
        var lines = Lines;

        List<int> rowsToExpand = FindRowsToExpand(lines).ToList();
        List<int> colsToExpand = FindColsToExpand(lines).ToList();
        var coords = FindGalaxyCoordinates(lines);

        for (int i = 0; i < coords.Count - 1; i++)
        {
            for (int j = i + 1; j < coords.Count; j++)
            {
                var r1 = coords[i].Real;
                var c1 = coords[i].Imaginary;

                var r2 = coords[j].Real;
                var c2 = coords[j].Imaginary;

                var intersectionsWithEmptyRows = rowsToExpand.Count(x => (r1 < x && x < r2)
                    || (r2 < x && x < r1));
                var intersectionsWithEmptyCols = colsToExpand.Count(x => (c1 < x && x < c2)
                    || (c2 < x && x < c1));

                var shortestPath = ShortestPath(coords[i], coords[j]);

                long intersections = intersectionsWithEmptyRows + intersectionsWithEmptyCols;

                sum += shortestPath + multiplier * intersections - intersections;
            }
        }


        return sum;
    }

    private int ShortestPath(Complex g1, Complex g2) 
        => (int)(Math.Abs(g1.Real - g2.Real) + Math.Abs(g1.Imaginary - g2.Imaginary));

    private List<Complex> FindGalaxyCoordinates(string[] lines)
    {
        var list = new List<Complex>();

        for (int row = 0; row < lines.Length; row++)
        {
            for (int col = 0; col < lines[0].Length; col++)
            {
                if (lines[row][col] == '#')
                {
                    list.Add(new Complex(row, col));
                }
            }
        }

        return list;
    }

    private static IEnumerable<int> FindRowsToExpand(string[] lines)
    {
        int rowsCount = lines.Length;

        for (int row = 0; row < rowsCount; row++)
        {
            if (lines[row].All(x => x == '.'))
            {
                yield return row;
            }
        }
    }

    private static IEnumerable<int> FindColsToExpand(string[] lines)
    {
        int rowsCount = lines.Length;
        int colsCount = lines[0].Length;

        for (int col = 0; col < colsCount; col++)
        {
            bool hasGalaxy = false;
            for (int row = 0; row < rowsCount; row++)
            {
                if (lines[row][col] == '#')
                {
                    hasGalaxy = true;
                    break;
                }
            }

            if (!hasGalaxy)
            {
                yield return col;
            }
        }
    }
}
