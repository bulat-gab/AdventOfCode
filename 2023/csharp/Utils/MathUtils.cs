using System.Drawing;
using System.Numerics;

namespace AdventOfCode2023.Utils;
public static class MathUtils
{
    public static long FindGCD(long a, long b)
    {
        while (b != 0)
        {
            var t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    public static long FindLCM(int[] numbers)
    {
        long lcm = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            lcm = FindLCM(lcm, numbers[i]);
        }

        return lcm;
    }

    public static long FindLCM(long a, long b)
    {
        var multiple = a * b;
        var gcd = FindGCD(a, b);

        return multiple / gcd;
    }

    // y = Ax + B
    public static (double A, double B) FindLineCoefficients(Complex p1, Complex p2)
    {
        try
        {
            checked
            {
                var xa = p1.Real;
                var xb = p2.Real;

                var ya = p1.Imaginary;
                var yb = p2.Imaginary;

                var deltaX = xb - xa;
                var deltaY = yb - ya;


                var A = deltaY / deltaX;
                var B = ya - ((deltaY * xa) / deltaX);

                return (A, B);
            }
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    
    /// <summary>
    ///y = A1*x + B1
    // y = A2*x + B2
    // x = (B2 - B1) / (A1 - A2)
    /// </summary>
    /// <param name="A1"></param>
    /// <param name="B1"></param>
    /// <param name="A2"></param>
    /// <param name="B2"></param>
    /// <returns></returns>
    public static Complex? FindIntersection(double A1, double B1, double A2, double B2)
    {
        if (A1 == A2)
        {
            // lines are parallel
            return null;
        }

        try
        {
            checked
            {
                var x = (B2 - B1) / (A1 - A2);
                var y = A1 * x + B1;

                return new Complex(x, y);
            }
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public static Complex? GetIntersectionPoint(Complex p1, Complex p2, Complex p3, Complex p4)
    {
        double x1 = p1.Real, y1 = p1.Imaginary;
        double x2 = p2.Real, y2 = p2.Imaginary;
        double x3 = p3.Real, y3 = p3.Imaginary;
        double x4 = p4.Real, y4 = p4.Imaginary;

        double denominator = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

        if (denominator == 0)
        {
            // Lines are parallel or coincident, no intersection
            return null;
        }

        double intersectX = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denominator;
        double intersectY = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denominator;

        return new Complex(intersectX, intersectY);
    }
}
