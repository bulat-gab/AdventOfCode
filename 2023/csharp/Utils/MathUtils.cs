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
}
