
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day5;
public class Solution
{
    private string[] Maps;
    private long[] Seeds;

    public Solution()
    {
        var input = File.ReadAllText("./Day5/input.txt");
        var parts = input.Split([Environment.NewLine + Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);

        Seeds = Regex.Matches(parts[0], @"\d+").Select(x => long.Parse(x.Value)).ToArray();
        Maps = parts.Skip(1).ToArray();
    }

    public long PartOne()
    {
        var ranges = Seeds.Select(x => new Range(x, x)).ToList();
        foreach (var map in Maps)
        {
            ranges = FindNextRange(ranges, map);
        }

        return ranges
            .Select(x => x.begin)
            .Min();
    }

    public long PartTwo()
    {
        List<Range> ranges = [];
        for (int i = 0; i < Seeds.Length - 1; i += 2)
        {
            Range range = new(Seeds[i], Seeds[i] + Seeds[i + 1] - 1);
            ranges.Add(range);
        }

        foreach (var map in Maps)
        {
            ranges = FindNextRange(ranges, map);
        }

        return ranges
            .Select(x => x.begin)
            .Min();
    }

    private bool Intersects(Range a, Range b) => a.begin <= b.end && a.end >= b.begin;

    private List<Range> FindNextRange(List<Range> inputRanges, string map)
    {
        List<(Range dst, Range src)> list = ParseMap(map).ToList();

        var q = new Queue<Range>(inputRanges);
        var output = new List<Range>();

        while (q.Count > 0)
        {
            var r = q.Dequeue();

            var (dst, src) = list.FirstOrDefault(x => Intersects(x.src, r));

            // no intersection
            if (src == null)
            {
                output.Add(r);
            }

            // r interval is inside src interval
            else if (src.begin <= r.begin && r.end <= src.end)
            {
                var s = dst.begin + (r.begin - src.begin);
                var e = dst.begin + (r.end - src.begin);
                output.Add(new Range(s, e));
            }
            else if (r.begin < src.begin)
            {
                q.Enqueue(new Range(r.begin, src.begin - 1));
                q.Enqueue(new Range(src.begin, r.end));
            }
            else
            {
                q.Enqueue(new Range(r.begin, src.end));
                q.Enqueue(new Range(src.end + 1, r.end));
            }
        }


        return output;

    }

    private IEnumerable<(Range dest, Range src)> ParseMap(string map)
    {
        var mapLines = map.Split(Environment.NewLine).ToArray();
        mapLines = mapLines[1..];

        foreach (var line in mapLines)
        {
            var (dst, src, range) = ParseNumbers(line);

            var dstRange= new Range(dst, dst + range - 1);
            var srcRange = new Range(src, src + range - 1);

            yield return (dstRange, srcRange);
        }

        Console.WriteLine(  );

    }

    private static (long destination, long source, long range) ParseNumbers(string line)
    {
        var triple = Regex.Matches(line, @"\d+").Select(x => long.Parse(x.Value)).ToArray();

        return (triple[0], triple[1], triple[2]);
    }

    private record Range(long begin, long end);
}
