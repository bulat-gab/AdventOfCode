using System.Diagnostics;



Stopwatch sw = Stopwatch.StartNew();

var r1 = new AdventOfCode2023.Day5.Solution().PartOne();
Console.WriteLine("R1: " + r1);
if (r1 != 178159714)
//if (r1 != 35)
{
    throw new Exception();
}

var r2 = new AdventOfCode2023.Day5.Solution().PartTwo();
Console.WriteLine("R2: " + r2);
//if (r2 != 46)
if (r2 != 100165128)
{
    throw new Exception();
}




sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);

