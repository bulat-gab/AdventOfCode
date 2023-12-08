namespace AdventOfCode.Day4;
public class Day4
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
        var lines = File.ReadAllLines("./Day4/input.txt");

        int score = 0;
        foreach (var line in lines)
        {
            var localScore = 0;

            var split = line.Split(':');
            var numbers = split[1].Split("|");

            var winningNumbers = TrimAndSplitStringToIntArray(numbers[0]);
            var myNumbers = TrimAndSplitStringToIntArray(numbers[1]);

            var winningNumbersSet = winningNumbers.ToHashSet();

            var winningTickets = 0;

            //Console.WriteLine(line);

            foreach (var number in myNumbers)
            {
                if (winningNumbersSet.Contains(number))
                {
                    if (winningTickets == 0)
                    {
                        localScore = 1;
                    }
                    if (winningTickets > 0)
                    {
                        localScore *= 2;
                    }

                    //Console.Write(localScore + " ");


                    winningTickets++;
                }
            }

            //Console.Write(" = " + localScore);
            //Console.WriteLine();
            score += localScore;

        }

        Console.WriteLine(score);
        return score;

    }

    public int PartTwo()
    {
        return 0;
    }
}
