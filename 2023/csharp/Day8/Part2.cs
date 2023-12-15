using static AdventOfCode2023.Utils.MathUtils;

namespace AdventOfCode2023.Day8;

public class Part2
{
    private const char ToLeft = 'L';
    private const char ToRight = 'R';

    private readonly string Instructions;
    private readonly Dictionary<string, (string, string)> AdjacencyList = new();

    private readonly List<string> StartNodes = new();
    private readonly List<string> EndNodes = new();

    public Part2()
    {
        var lines = File.ReadAllLines("./Day8/input.txt");

        this.Instructions = lines[0];

        for (int i = 2; i < lines.Length; i++)
        {
            var (current, left, right) = ParseInput(lines[i]);

            AdjacencyList.Add(current, (left, right));
            if (current.EndsWith("A"))
            {
                StartNodes.Add(current);
            }
            if (current.EndsWith("Z"))
            {
                EndNodes.Add(current);
            }
        }
    }

    public long Solve()
    {
        var numberOfStartNodes = StartNodes.Count;
        var steps = new int[numberOfStartNodes];

        for (int i = 0; i < numberOfStartNodes; i++)
        {
            steps[i] = GetSteps(StartNodes[i]);
        }

        var lcm = FindLCM(steps);

        Console.WriteLine("Step: " + lcm);


        return lcm;
    }

    

    private int GetSteps(string startNode)
    {
        int steps = 0;
        string currentNode = startNode;
        int instructionIndex = 0;
        while (!EndNodes.Contains(currentNode))
        {
            var currentinstruction = Instructions[instructionIndex];
            var nodePair = AdjacencyList[currentNode];

            var next = GetNextNode(currentinstruction, nodePair);

            steps++;
            instructionIndex++;
            if (instructionIndex >= Instructions.Length)
            {
                instructionIndex = 0;
            }

            currentNode = next;
            Console.Write($"\rNode: {startNode}; Step: {steps}   ");
        }

        Console.WriteLine();
        return steps;
    }

    private static string GetNextNode(char currentInstruction, (string left, string right) nodePair)
    {
        if (currentInstruction == ToLeft)
        {
            return nodePair.left;
        }
        else if (currentInstruction == ToRight)
        {
            return nodePair.right;
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private static (string Current, string Left, string Right) ParseInput(string input)
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
