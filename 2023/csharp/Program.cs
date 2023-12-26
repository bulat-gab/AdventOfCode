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



var r = new AdventOfCode2023.Day24.Solution().PartOne();
Console.WriteLine("Result: " + r);

sw.Stop();
Console.WriteLine("=====================================");
Console.WriteLine("Elapsed ms={0}", sw.Elapsed.TotalMilliseconds);

