namespace AdventOfCode2023.Day6;
public class Part1
{
    private int[] SplitStringIntoIntArray(string input)
    {
        return input
            .Split(':')[1]
            .Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => int.Parse(x))
            .ToArray();
    }

    private int CalculateDistanceTravelled(int speed, int time) => speed * time;

    private int CalculateNumberOfWaysToWin(int time, int distance)
    {
        int numberOfWays = 0;

        for (int timePressed = 1; timePressed < time; timePressed++)
        {
            var speed = timePressed;
            var timeTravelled = time - timePressed;

            var distanceTravelled = CalculateDistanceTravelled(speed, timeTravelled);
            if (distanceTravelled > distance)
            {
                numberOfWays++;
            }
        }

        Console.WriteLine($"Time: {time}; Distance: {distance}; Number of ways: {numberOfWays}");
        return numberOfWays;
    }


    public int PartOne()
    {
        var lines = File.ReadAllLines("./Day6/input.txt");

        var times = SplitStringIntoIntArray(lines[0]);
        var distances = SplitStringIntoIntArray(lines[1]);

        if (times.Length != distances.Length)
        {
            throw new ArgumentException();
        }

        int product = 1;
        for (int i = 0; i < times.Length; i++)
        {
            product *= CalculateNumberOfWaysToWin(times[i], distances[i]);
        }



        Console.WriteLine($"Answer: {product}");
        return product;

    }
}
