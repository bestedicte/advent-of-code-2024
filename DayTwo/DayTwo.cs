namespace AOC.DayTwo;

public class DayTwoResult
{
    public int SafeRowCount { get; set; }
    public int TotalSafeRowCount { get; set; }

    public override string ToString()
    {
        return $"SafeRowCount: {SafeRowCount}, " +
               $"TotalSafeRowCount: {TotalSafeRowCount}";
    }
}

public class DayTwo
{
    private static string[] ParseInput()
    {
        return File.ReadAllLines("DayTwo/input.txt");
    }

    private static int[] ParseLevels(string input)
    {
        return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    }

    private static bool AreLevelsInSequence(int[] levels, Func<int, int, bool> comparison)
    {
        for (var i = 0; i < levels.Length - 1; i++)
            if (!comparison(levels[i], levels[i + 1]))
                return false;
        return true;
    }

    private static bool HasValidLevelDifferences(int[] levels)
    {
        return !levels.Zip(levels.Skip(1), (first, second) => Math.Abs(second - first))
            .Any(diff => diff < 1 || diff > 3);
    }

    private static bool CanBeMadeSafe(int[] levels)
    {
        for (var i = 0; i < levels.Length; i++)
        {
            var modifiedLevels = levels.Where((_, index) => index != i).ToArray();

            if ((AreLevelsInSequence(modifiedLevels, (current, next) => current < next) ||
                 AreLevelsInSequence(modifiedLevels, (current, next) => current > next)) &&
                HasValidLevelDifferences(modifiedLevels))
                return true;
        }

        return false;
    }

    public static DayTwoResult Run()
    {
        var inputLines = ParseInput();
        var safeRowCount = 0;
        var additionalSafeRowCount = 0;

        foreach (var line in inputLines)
        {
            var levels = ParseLevels(line);
            var increasing = AreLevelsInSequence(levels, (current, next) => current < next);
            var decreasing = AreLevelsInSequence(levels, (current, next) => current > next);


            if ((increasing || decreasing) && HasValidLevelDifferences(levels))
                safeRowCount++;
            else if (CanBeMadeSafe(levels)) additionalSafeRowCount++;
        }

        return new DayTwoResult
        {
            SafeRowCount = safeRowCount,
            TotalSafeRowCount = safeRowCount + additionalSafeRowCount
        };
    }
}