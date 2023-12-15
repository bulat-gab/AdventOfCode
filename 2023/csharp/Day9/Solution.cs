using System.Collections.Generic;

namespace AdventOfCode2023.Day9;
public class Solution
{
    private readonly string[] Lines;

    public Solution()
    {
        Lines = File.ReadAllLines("./Day9/input.txt");
    }

    public int PartOne()
    {
        return Lines
            .Select(line => line.Split(" ").Select(int.Parse).ToList())
            .Select(FillSequences)
            .Select(x => ExtrapolateRight(x))
            .Select(x => x[0][^1])
            .Sum();
    }

    public int PartTwo()
    {
        return Lines
            .Select(line => line.Split(" ").Select(int.Parse).ToList())
            .Select(FillSequences)
            .Select(x => ExtrapolateLeft(x))
            .Select(x => x[0][0])
            .Sum();
    }

    private List<List<int>> ExtrapolateRight(List<List<int>> sequences)
    {
        for (var sequenceIndex = sequences.Count() - 1; sequenceIndex > 0; sequenceIndex--)
        {
            var bottom = sequences[sequenceIndex][^1];
            var left = sequences[sequenceIndex - 1][^1];

            int newValue = left + bottom;


            sequences[sequenceIndex - 1].Add(newValue);
        }

        return sequences;
    }


    private List<List<int>> ExtrapolateLeft(List<List<int>> sequences)
    {
        for (var sequenceIndex = sequences.Count() - 1; sequenceIndex > 0; sequenceIndex--)
        {
            var bottom = sequences[sequenceIndex][0];
            var left = sequences[sequenceIndex - 1][0];

            var newValue = left - bottom;

            sequences[sequenceIndex - 1].Insert(0, newValue);

        }

        return sequences;
    }

    private List<List<int>> FillSequences(List<int> input)
    {
        var sequences = new List<List<int>>
        {
            input
        };

        int sequenceIndex = 0;

        while (true)
        {
            var tempList = new List<int>();

            for (int i = 1; i < sequences[sequenceIndex].Count; i++)
            {
                var difference = sequences[sequenceIndex][i] - sequences[sequenceIndex][i - 1];
                tempList.Add(difference);
            }

            sequences.Add(tempList);
            sequenceIndex++;
            if (tempList.All(x => x == 0))
            {
                break;
            }
        }

        return sequences.ToList();
    }
}
