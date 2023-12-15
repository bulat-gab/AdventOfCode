using System.Diagnostics;



Stopwatch sw = Stopwatch.StartNew();


var r1 = new AdventOfCode2023.Day15.Solution().PartOne();
Console.WriteLine("r1: " + r1);
if (r1 != 515495)
{
    Console.WriteLine("Invalid");
}

var r2 = new AdventOfCode2023.Day15.Solution().PartTwo();
Console.WriteLine("r2: " + r2);
if (r2 != 229349)
{
    Console.WriteLine("Invalid");
}

Console.WriteLine(  );


sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);

