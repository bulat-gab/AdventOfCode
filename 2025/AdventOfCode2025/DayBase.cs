namespace AdventOfCode2025;

public abstract class DayBase
{
    public abstract string DayNumber { get; }
    
    public string[] ReadInput()
    {
        var lines = File.ReadAllLines($"./Day{DayNumber}/input{DayNumber}");
        return lines;
    }
}