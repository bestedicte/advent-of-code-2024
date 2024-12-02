using AOC.DayOne;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("AdventOfCode 2024");
        var dayOne = DayOne.Run();
        Console.WriteLine($"Day One, Part One: {dayOne.TotalDifference}");
        Console.WriteLine($"Day One, Part Two: {dayOne.TotalSum}");
    }
}