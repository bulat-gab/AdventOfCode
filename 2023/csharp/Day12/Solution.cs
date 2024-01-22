

namespace AdventOfCode2023.Day12;
public class Solution
{
    private readonly string[] Lines;

    //static HashSet<string> Combinations = [];

    public Solution()
    {
        Lines = File.ReadAllLines("./Day12/input.txt");
    }

    /* . - operational
     * # - broken
     * ? - unknown
     * numbers - size of contigious group of damaged 
     * 
     * 
     * **/
    public int PartOne()
    {
        return Lines
            .Select(ParseLine)
            .Select(pair => FindCombinations(pair.Springs, pair.Numbers))
            .Sum();
    }

    public int PartTwo()
    {
        return Lines
             .Select(ParseLine2)
             .Select(pair => FindCombinations(pair.Springs, pair.Numbers))
             .Sum();
    }

    private (string Springs, int[] Numbers) ParseLine(string line)
    {
        var parts = line.Split(' ');

        return (parts[0], parts[1].Split(',').Select(int.Parse).ToArray());
    }

    private (string Springs, int[] Numbers) ParseLine2(string line)
    {
        var parts = line.Split(' ');
        var springs = string.Join("", Enumerable.Repeat(parts[0], 5));
        var numbersString = string.Join("", Enumerable.Repeat(parts[1], 5));
        var numbers = numbersString.Split(',').Select(int.Parse).ToArray();

        return (springs, numbers);
    }

    /* 
     * Produce all possible combinations of the springs
     * for each spring check if it fits into numbers rule
     * 
    **/
    private int FindCombinations(string springs, int[] numbers)
    {
        
        var combinations = GetAllCombinations(springs);
        var filtered = combinations
            .Where(x => IsValidCombination(x, numbers))
            .ToList();

        return filtered.Count();
    }

    private HashSet<string> GetAllCombinations(string springs)
    {
        var questionMarkIndices = new List<int>();

        for (int i = 0; i < springs.Length; i++)
        {
            if (springs[i] == '?')
                questionMarkIndices.Add(i);
        }

        var allCombinations = new HashSet<string>();
        var chars = springs.ToCharArray();

        Recurse(chars, questionMarkIndices, 0, '.', allCombinations);
        Recurse(chars, questionMarkIndices, 0, '#', allCombinations);

        return allCombinations;
    }

    private char[] Recurse(char[] chars, List<int> indices, int index, char value, HashSet<string> result)
    {
        if (index >= indices.Count)
        {
            return chars;
        }

        var charsIndex = indices[index];
        chars[charsIndex] = value;

        if (!chars.Contains('?'))
        {
            result.Add(new string(chars));
        }

        Recurse(chars, indices, index + 1, '.', result);
        Recurse(chars, indices, index + 1, '#', result);

        return chars;
    }

    private bool IsValidCombination(string combination, int[] numbers)
    {
        var length = combination.Length;
        var numbersIndex = 0;
        var charIndex = 0;

        while (charIndex < length)
        {
            int ch = combination[charIndex];
            int number = 0;

            if (numbersIndex < numbers.Length)
            {
                number = numbers[numbersIndex];
            }

            if (ch != '#')
            {
                charIndex++;

                if (charIndex >= length)
                {
                    // the last operational spring
                    return number == 0;
                }

                continue;
            }

            while (number > 0)
            {
                if (charIndex >= length || combination[charIndex] != '#')
                {
                    return false;
                }

                number--;
                charIndex++;
            }

            if (charIndex < length)
            {
                // The broken spring must be followed by operational spring
                if (combination[charIndex] != '.')
                {
                    return false;
                }
            }

            numbersIndex++;
        }

        // there are some numbers left that do not correspond to the pattern
        if (numbersIndex < numbers.Length)
        {
            return false;
        }

        return true;
    }


}
