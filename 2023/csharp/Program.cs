using System.Diagnostics;



Stopwatch sw = Stopwatch.StartNew();

//var r1 = new AdventOfCode.Day1.Day1().PartOne();
//if (r1 != 54597)
//{
//    Console.WriteLine("Part 1 Invalid Answer");
//}

//var r2 = new AdventOfCode2023.Day1.Day1().PartTwo();
//Console.WriteLine("Answer Part 2: " + r2);
//if (r2 != 281)
//{
//    Console.WriteLine("Part 2 Invalid Answer");
//}


var r1 = new AdventOfCode2023.Day9.Solution().PartOne();
Console.WriteLine("r1: " + r1);
if (r1 != 1757008019)
{
    Console.WriteLine("Part 1 Invalid Answer");
}

Console.WriteLine(  );

var r2 = new AdventOfCode2023.Day9.Solution().PartTwo();
Console.WriteLine("r2: " + r2);
if (r2 != 995)
{
    Console.WriteLine("Part 2 Invalid Answer");
}




sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);

