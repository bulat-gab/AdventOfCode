using System.Diagnostics;



Stopwatch sw = Stopwatch.StartNew();

//var r13 = new AdventOfCode2023.Day10.Solution("./Day10/input3.txt").PartOne();
//Console.WriteLine("R13: " + r13);
//if (r13 != 4)
//{
//    throw new Exception();
//}

//var r1 = new AdventOfCode2023.Day10.Solution("./Day10/input.txt").PartOne();
//Console.WriteLine("R11: " + r1);
//if (r1 != 6725)
//{
//    throw new Exception();
//}

//var r12 = new AdventOfCode2023.Day10.Solution("./Day10/input2.txt").PartOne();
//Console.WriteLine("R12: " + r12);
//if (r12 != 5)
//{
//    throw new Exception();
//}



var r1 = new AdventOfCode2023.Day11.Solution().PartOne();
Console.WriteLine("Result: " + r1);
if (r1 != 9965032)
{
    throw new Exception();
}

var r2 = new AdventOfCode2023.Day11.Solution().PartTwo();
Console.WriteLine("Result: " + r2);
if (r2 != 550358864332)
{
    throw new Exception();
}

sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);

