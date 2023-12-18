using System.Diagnostics;



Stopwatch sw = Stopwatch.StartNew();

var r1 = new AdventOfCode2023.Day16.Solution().PartOne();
Console.WriteLine("R1: " + r1);
if (r1 != 8901)
{
    throw new Exception();
}

var r2 = new AdventOfCode2023.Day16.Solution().PartTwo();
Console.WriteLine("R: " + r2);
if (r2 != 9064)
{
    throw new Exception();
}




sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);

