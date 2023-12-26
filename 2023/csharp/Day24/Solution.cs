using AdventOfCode2023.Utils;
using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day24;
public class Solution
{
    private readonly string[] Lines;
    private const long Min = 200000000000000;
    private const long Max = 400000000000000;

    //private const long Min = 7;
    //private const long Max = 27;

    public Solution()
    {
        Lines = File.ReadAllLines("./Day24/input.txt");
    }

    public long PartOne()
    {
        List<Hail> hails = Lines
            .Select(line => new Hail(ParseNumbers(line)))
            .ToList();

        long sum = 0;
        for (var i = 0; i < hails.Count - 1; i++)
        {
            for (var j = i + 1; j < hails.Count; j++)
            {
                var hail1 = hails[i];
                var hail2 = hails[j];
                var intersection = FindHailsIntersection2(hail1, hail2);
                
                if (intersection != null)
                {
                    //Console.WriteLine($"Hailstone A: {hail1}");
                    //Console.WriteLine($"Hailstone B: {hail2}");
                    Console.WriteLine(intersection);
                    //Console.WriteLine();
                    sum++;
                }
            }
        }


        return sum;
    }

    private Complex? FindHailsIntersection(Hail hail1, Hail hail2)
    {
        var point1 = new Complex(hail1.X, hail1.Y);
        var point2 = new Complex(hail1.X + hail1.Dx, hail1.Y + hail1.Dy);
        var (A1, B1) = MathUtils.FindLineCoefficients(point1, point2);


        var point3 = new Complex(hail2.X, hail2.Y);
        var point4 = new Complex(hail2.X + hail2.Dx, hail2.Y + hail2.Dy);
        var (A2, B2) = MathUtils.FindLineCoefficients(point3, point4);


        var intersection = MathUtils.FindIntersection(A1, B1, A2, B2);
        if (intersection == null)
        {
            return null;
        }

        if (!IsIntersectionInsideTestArea(hail1, intersection.Value) 
            || !IsIntersectionInsideTestArea(hail2, intersection.Value))
        {
            return null;
        }

        return intersection;
    }

    private Complex? FindHailsIntersection2(Hail hail1, Hail hail2)
    {
        var point1 = new Complex(hail1.X, hail1.Y);
        var point2 = new Complex(hail1.X + hail1.Dx, hail1.Y + hail1.Dy);

        var point3 = new Complex(hail2.X, hail2.Y);
        var point4 = new Complex(hail2.X + hail2.Dx, hail2.Y + hail2.Dy);

        var intersection = MathUtils.GetIntersectionPoint(point1, point2, point3, point4);
        if (intersection == null)
        {
            return null;
        }

        if (!IsIntersectionInsideTestArea(hail1, intersection.Value)
            || !IsIntersectionInsideTestArea(hail2, intersection.Value))
        {
            return null;
        }

        return intersection;
    }

    private bool IsIntersectionInsideTestArea(Hail hail, Complex intersection)
    {
        var x = intersection.Real;
        var y = intersection.Imaginary;

        if (!IsIntersectionInFuture(hail.X, x, hail.Dx)
            || !IsIntersectionInFuture(hail.Y, y, hail.Dy))
            return false;

        if (Min <= hail.X && hail.X <= Max
            && Min <= hail.Y && hail.Y <= Max)
            return true;

        return false;
    }

    private bool IsIntersectionInFuture(long coord, double intersection, long velocity)
    {
        if (coord > intersection && velocity > 0 || coord < intersection && velocity < 0)
        {
            return false;
        }

        return true;
    }


    private long[] ParseNumbers(string input) =>
        Regex.Matches(input, @"[-]?\d+")
        .Select(x => long.Parse(x.Value))
        .ToArray();

    private record Coordinate(long X, long Y, long Z)
    {
        public Coordinate(long[] input) : this(input[0], input[1], input[2])
        {
        }
    }

    private record Velocity(long Dx, long Dy, long Dz)
    {
        public Velocity(long[] input) : this(input[0], input[1], input[2])
        {
        }
    }

    record Hail
    {
        public long X { get; init; }
        public long Y { get; init; }
        public long Z { get; init; }
        public long Dx { get; init; }
        public long Dy { get; init; }
        public long Dz { get; init; }


        public Hail(long[] input)
        {
            X = input[0];
            Y = input[1];
            Z = input[2];
            Dx = input[3];
            Dy = input[4];
            Dz = input[5];
        }
    }
}

