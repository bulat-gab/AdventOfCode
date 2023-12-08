namespace AdventOfCode.Day1;
public class Day1
{
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
        //var lines = File.ReadAllLines("./Day1/test-input.txt");

        var numbers = new Dictionary<string, int>()
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

        int sum = 0;

        int lineNumber = 1;

        foreach (var line in lines)
        {
            Console.WriteLine(lineNumber);
            lineNumber++;

            string firstDigit = null;
            string lastDigit;
            string currentSubstring;
            string currentDigit = null;
            int digitChanges = 0;

            for (var i = 0; i < line.Length; i++)
            {
                currentSubstring = line[i].ToString();

                if (int.TryParse(currentSubstring, out var parsed))
                {
                    currentDigit = currentSubstring;
                    digitChanges++;

                    if (firstDigit == null)
                    {
                        firstDigit = currentDigit;
                        continue;
                    }
                }

                for (var wordLength = 3; wordLength < 6 && i + wordLength <= line.Length; wordLength++)
                {
                    currentSubstring = line.Substring(i, wordLength);
                    if (numbers.ContainsKey(currentSubstring))
                    {
                        currentDigit = currentSubstring;
                        digitChanges++;

                        if (firstDigit == null)
                        {
                            firstDigit = currentSubstring;
                        }

                        i = i + wordLength - 1;
                        break;
                    }
                }
            }
            lastDigit = currentDigit;

            Console.WriteLine("First: " + firstDigit);
            Console.WriteLine("Last: " + lastDigit);
            Console.WriteLine();

            if (firstDigit == null || digitChanges < 2)
            {
                continue;
            }

            int firstDigitConverted;
            if (numbers.TryGetValue(firstDigit, out var parsed2))
            {
                firstDigitConverted = parsed2;
            }
            else
            {
                firstDigitConverted = int.Parse(firstDigit);
            }

            int lastDigitConverted;
            if (numbers.TryGetValue(lastDigit, out parsed2))
            {
                lastDigitConverted = parsed2;
            }
            else
            {
                lastDigitConverted = int.Parse(lastDigit);
            }

            var fl = int.Parse($"{firstDigitConverted}{lastDigitConverted}");

            sum += fl;

            Console.WriteLine("Digits Change: " + digitChanges);
        }

        Console.WriteLine(sum);
        return sum;
    }
}
