using System.Diagnostics;



Stopwatch sw = Stopwatch.StartNew();

var r1 = new AdventOfCode2023.Day4.Solution().PartOne();
Console.WriteLine("R1: " + r1);
if (r1 != 17782)
{
    throw new Exception();
}

var r2 = new AdventOfCode2023.Day4.Solution().PartTwo();
Console.WriteLine("R2: " + r2);
if (r2 != 8477787)
{
    throw new Exception();
}




sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);

