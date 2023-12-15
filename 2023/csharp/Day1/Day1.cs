namespace AdventOfCode2023.Day1;
public class Day1
{
    private readonly Dictionary<string, int> numbers = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        };

    public int PartOne()
    {
        var lines = File.ReadAllLines("./Day1/input.txt");

        int sum = 0;

        foreach (var line in lines)
        {
            char current = 'Z';
            char firstDigit = 'Z';

            foreach (var c in line)
            {
                if (int.TryParse(c.ToString(), out var parsed))
                {
                    current = c;

                    if (firstDigit == 'Z')
                    {
                        firstDigit = c;
                    }
                }
            }

            var x = int.Parse($"{firstDigit}{current}");
            sum += x;
        }

        Console.WriteLine(sum);
        return sum;
    }

    public int PartTwo()
    {
        var lines = File.ReadAllLines("./Day1/input.txt");

        var sum = 0;


        foreach (var line in lines)
        {
            string firstDigit = "";
            string lastDigit = "";

            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];

                if (int.TryParse(c.ToString(), out var parsedChar))
                {
                    if (firstDigit == "")
                    {
                        firstDigit = c.ToString();
                    }

                    lastDigit = c.ToString();
                }

                int wordLength = 3;
                while (i + wordLength <= line.Length && wordLength <= 5)
                {
                    var substring = line[i..(i + wordLength)];
                    if (numbers.ContainsKey(substring))
                    {
                        if (firstDigit == "")
                        {
                            firstDigit = substring;
                        }
                        lastDigit = substring;
                    }

                    wordLength++;
                }
            }

            var first = ParseString(firstDigit);
            var last = ParseString(lastDigit);

            var subResult = int.Parse($"{first}{last}");
            sum += subResult;
        }


        return sum;
    }

    private int ParseString(string input)
    {
        if (int.TryParse(input, out var result))
        {
            return result;
        }

        if (numbers.TryGetValue(input, out result))
        {
            return result;
        }

        throw new ArgumentException($"Cannot parse a string {input} to a number.");
    }
}
