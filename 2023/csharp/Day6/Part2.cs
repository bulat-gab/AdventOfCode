namespace AdventOfCode2023.Day6;
public class Part2
{
    private long ParseToInt(string input)
    {
        var stringNumber = input
            .Split(':')[1]
            .Replace(" ", "");

        return long.Parse(stringNumber);
    }

    private long CalculateDistanceTravelled(long speed, long time) => speed * time;

    private long CalculateNumberOfWaysToWin(long time, long distance)
    {
        var numberOfWays = 0;

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


    public long PartTwo()
    {
        var lines = File.ReadAllLines("./Day6/input.txt");

        var time = ParseToInt(lines[0]);
        var distance = ParseToInt(lines[1]);

        Console.WriteLine($"Time: {time}");
        Console.WriteLine($"Distance: {distance}");

        var answer = CalculateNumberOfWaysToWin(time, distance);

        Console.WriteLine($"Answer: {answer}");
        return answer;

    }
}
