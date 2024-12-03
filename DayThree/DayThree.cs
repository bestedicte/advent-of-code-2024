using System.Text.RegularExpressions;

namespace AOC.DayThree;

public class DayThreeResult
{
    public int MultiplierTotal { get; set; }

    public override string ToString()
    {
        Console.WriteLine(MultiplierTotal);
        return $"MultiplierTotal: {MultiplierTotal}";
    }
}

public class DayThree
{
    private static string ReadInput()
    {
        using StreamReader reader = new("DayThree/input.txt");
        return reader.ReadToEnd();
    }

    private static List<(int, int)> FindValidMultipliers(string input)
    {
        var validMultipliers = new List<(int, int)>();
        var pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

        var matches = Regex.Matches(input, pattern);
        foreach (Match match in matches)
        {
            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);
            validMultipliers.Add((x, y));
        }

        return validMultipliers;
    }

    public static DayThreeResult Run()
    {
        var input = ReadInput();
        var validMultipliers = FindValidMultipliers(input);

        var total = 0;
        foreach (var (x, y) in validMultipliers)
            total += x * y;

        return new DayThreeResult { MultiplierTotal = total };
    }
}