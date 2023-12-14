using System.Diagnostics;



Stopwatch sw = Stopwatch.StartNew();

var result = new AdventOfCode.Day3.Solution().PartOne();
Console.WriteLine("Part One Answer: " + result);

if (result != 559667)
{
    throw new Exception();
}

var r2 = new AdventOfCode.Day3.Solution().PartTwo();
Console.WriteLine("Part Two Answer: " + r2);
if (r2 != 86841457)
{
    throw new Exception();
}



sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);


//var line = "..35..633.";
//var start = 2;
//var end = 3;
//var Width = line.Length;

//var truncatedStart = Math.Max(start, 0);
//var truncatedEnd = Math.Min(end + 1, Width - 1);

//var substring = line[truncatedStart..truncatedEnd];

//Console.WriteLine(substring);

//var x1 = new AdventOfCode.Day3.Solution2().ParseNumber(0, 0);
//Console.WriteLine(x1);

//var x2 = new AdventOfCode.Day3.Solution2().ParseNumber(5, 0);
//Console.WriteLine(x2);

//var x3 = new AdventOfCode.Day3.Solution2().ParseNumber(9, 0);
//Console.WriteLine(x3);