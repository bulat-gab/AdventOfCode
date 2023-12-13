using System.Diagnostics;

//new Day1().PartOne();
//new Day1().PartTwo();

//new Day4().PartOne();

//new AdventOfCode.Day6.Part1().PartOne();

Stopwatch sw = Stopwatch.StartNew();

//new AdventOfCode.Day6.Part2().PartTwo();

//Console.WriteLine("=====================================");
//Console.WriteLine("=====================================");
//Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);


var result = new AdventOfCode.Day8.Part2().Solve();
Console.WriteLine("Answer: " + result);











sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);