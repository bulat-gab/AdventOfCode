using System.Diagnostics;



Stopwatch sw = Stopwatch.StartNew();


var r = new AdventOfCode2023.Day10.Solution().PartOne();



sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);

