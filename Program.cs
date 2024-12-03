using AOC.DayOne;
using AOC.DayThree;
using AOC.DayTwo;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("AdventOfCode 2024");
        var dayOne = DayOne.Run();
        Console.WriteLine($"Day One, Part One: {dayOne.TotalDifference}");
        Console.WriteLine($"Day One, Part Two: {dayOne.TotalSum}");
        var dayTwo = DayTwo.Run();
        Console.WriteLine($"Day Two, Part One: {dayTwo.SafeRowCount}");
        Console.WriteLine($"Day Two, Part Two: {dayTwo.TotalSafeRowCount}");
        var dayThree = DayThree.Run();
        Console.WriteLine($"Day Three, Part One: {dayThree.MultiplierTotal}");
    }
}