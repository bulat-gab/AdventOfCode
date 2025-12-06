namespace AdventOfCode2025.day1;

public class Day1 : DayBase
{
    public override string DayNumber => "1";

    private Dictionary<char, int> _mapp = new()
    {
        {'L', -1}, {'R', 1}
    };
    
    public string PartOne()
    {
        var lines = ReadInput();

        const int modulus = 100;
        var start = 50;
        var result = 0;
        foreach (var line in lines)
        {
            var dir = line[0];
            var number = int.Parse(line[1..]);

            start += _mapp[dir] * number;
            start = (start % modulus + 100) % modulus;
            if (start == 0)
            {
                result++;
            }
        }
        
        return result.ToString();
    }
    
    public string PartTwo()
    {
        var lines = ReadInput();

        const int modulus = 100;
        var start = 50;
        var result = 0;
        foreach (var line in lines)
        {
            var dir = line[0];
            var number = int.Parse(line[1..]);

            start += _mapp[dir] * number;
            start = (start % modulus + 100) % modulus;
            if (start == 0)
            {
                result++;
            }
        }
        
        return result.ToString();
    }

}