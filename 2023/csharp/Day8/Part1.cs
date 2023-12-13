namespace AdventOfCode.Day8;
public class Part1
{
    private const char ToLeft = 'L';
    private const char ToRight = 'R';

    public int Solve()
    {
        var lines = File.ReadAllLines("./Day8/input.txt");

        var instructions = lines[0];

        var adjacencyList = new Dictionary<string, (string, string)>();

        string startNode = "";
        string endNode = "";

        for (int i = 2; i < lines.Length; i++)
        {
            var (current, left, right) = ParseInput(lines[i]);

            adjacencyList.Add(current, (left, right));
            if (current == "AAA")
            {
                startNode = current;
            }
            if (current == "ZZZ")
            {
                endNode = current;
            }
        }

        int steps = 0;
        string currentNode = startNode;
        int instructionIndex = 0;
        while (currentNode != endNode)
        {
            var currentinstruction = instructions[instructionIndex];
            var (left, right) = adjacencyList[currentNode];

            if (currentinstruction == ToLeft)
            {
                currentNode = left;
            }
            else if (currentinstruction == ToRight)
            {
                currentNode = right;
            }
            else
            {
                throw new NotImplementedException();
            }

            steps++;
            instructionIndex++;
            if (instructionIndex >= instructions.Length)
            {
                instructionIndex = 0;
            }

            Console.WriteLine("Step: " + steps);
        }


        Console.WriteLine($"Answer: {steps}");
        return steps;

    }

    private (string Current, string Left, string Right) ParseInput(string input)
    {
        var split = input.Split(" = ");
        var current = split[0];

        var split2 = split[1]
            .Replace(")", "")
            .Replace("(", "")
            .Split(", ");

        var left = split2[0];
        var right = split2[1];

        return (current, left, right);
    }
}
