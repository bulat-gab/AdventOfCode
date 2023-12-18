

namespace AdventOfCode2023.Day15;
public class Solution
{
    private readonly string[] Input;

    public Solution()
    {
        Input = File.ReadAllText("./Day15/input.txt")
            .Split(",");
    }

    public int PartOne()
    {
        return Input
            .Select(GetHash)
            .Sum();
    }

    private int GetHash(string input)
    {
        int hash = 0;

        foreach (var c in input)
        {
            hash += (int)c;
            hash *= 17;
            hash %= 256;
        }

        return hash;
    }

    private int GetHash2(string input)
    {
        int hash = 0;

        foreach (var c in input)
        {
            if (c == '=' || c == '-')
            {
                break;
            }

            hash += (int)c;
            hash *= 17;
            hash %= 256;
        }

        Console.WriteLine($"Label: {input}; Hash: {hash}");

        return hash;
    }


    /*
     * Each entry in the Input[] represents a box
     * Input[x] consists of:
     *  1) Label of the box (from 0 to 256)
     *  2) Operation (- or =)
     *         Operation "-" means remove the lense with the given label
     *              If such sense is not in the box do nothing
     *              Else remove it and shrink elements in the array (remove empty space)
     *         
     *         Operation "=" means adding a new lense
     *              If such lense already exists in the box update it's focal length.
     *              Else add the lense at the end
     *         
     *         
     *         
     * Inside each box is a lense
     * 
     * 
     **/
    public int PartTwo()
    {
        var boxes = new List<Lense>[256];
        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i] = new List<Lense>();
        }

        foreach (var step in Input)
        {
            Console.WriteLine();
            Console.WriteLine($"After \"{step}\":");

            var split = step.Split(['=', '-']).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var label = split[0];

            var boxId = GetHash(label);

            int focalLength = 0;

            // Adding a lense
            if (split.Length == 2)
            {
                focalLength = int.Parse(split[1]);

                var lense = new Lense(label, focalLength);

               var lenseToReplace = boxes[boxId].Where(x => x.Label == label).FirstOrDefault();
                if (lenseToReplace == null)
                {
                    boxes[boxId].Add(lense);
                }
                else
                {
                    var index = boxes[boxId].FindIndex(x => x.Label == lense.Label);
                    boxes[boxId][index] = new Lense(lense.Label, focalLength);
                }
            }
            else
            {
                // Removing a lense
                var box = boxes[boxId];
                for (int i = 0; i < box.Count; i++)
                {
                    if (box[i].Label != label)
                    {
                        continue;
                    }

                    while (i < box.Count - 1)
                    {
                        box[i] = box[i + 1];
                        i++;
                    }

                    box.RemoveAt(box.Count - 1);
                }
            }

            var toPrint = boxes
                .Select((val, i) => new { Value = val, Index = i })
                .Where(x => x.Value.Count() > 0)
                .ToList();

            foreach (var x in toPrint)
            {
                Console.Write($"Box {x.Index}: ");
                var lensess = string.Join(" ", x.Value.Select(x => $"[{x.Label} {x.FocalLength}]"));
                Console.WriteLine(lensess);
            }

        }

        //boxes = boxes.Where(x => x.Count > 0).ToArray();
        var dict = new Dictionary<string, List<int>>();
        for (int boxId = 0; boxId < boxes.Length; boxId++)
        {
            var box = boxes[boxId];
            for (int i = 0; i < box.Count; i++)
            {
                var currentLense = box[i];

                var tempFocusingPower = (i + 1) * (boxId + 1) * box[i].FocalLength;

                if (dict.TryGetValue(box[i].Label, out var llist))
                {
                    llist.Add(tempFocusingPower);
                    dict[box[i].Label] = llist;
                }
                else
                {
                    dict[box[i].Label] = [tempFocusingPower];
                }
            }
        }

        return dict.Sum(x => x.Value.Sum());
    }

    public record Lense(string Label, int FocalLength);
}
