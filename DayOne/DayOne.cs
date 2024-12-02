namespace AOC.DayOne;

public class DayOneResult
{
    public int TotalDifference { get; set; }
    public int TotalSum { get; set; }

    public override string ToString()
    {
        return $"TotalDifference: {TotalDifference}, TotalSum: {TotalSum}";
    }
}

public class DayOne
{
    private static string[] ParseInput()
    {
        using StreamReader reader = new("DayOne/input.txt");
        var text = reader.ReadToEnd();

        var lines = text.Split(Environment.NewLine);
        return lines;
    }

    private static (int, int) ExtractNumbers(string input)
    {
        var extractedNumbers = input.Split("   ");
        return (int.Parse(extractedNumbers[0]), int.Parse(extractedNumbers[1]));
    }

    public static DayOneResult Run()
    {
        var input = ParseInput();
        var columnA = new int[input.Length];
        var columnB = new int[input.Length];

        for (var row = 0; row < input.Length; row++)
        {
            var (numberA, numberB) = ExtractNumbers(input[row]);
            columnA[row] = numberA;
            columnB[row] = numberB;
        }

        Array.Sort(columnA);


        Dictionary<int, int> counts = new Dictionary<int, int>();
        foreach (int number in columnB)
        {
            if (counts.ContainsKey(number))
                counts[number]++;
            else
                counts[number] = 1;
        }

        // Calculate the total sum based on occurrences
        int totalSum = 0;
        foreach (int number in columnA)
        {
            int count = counts.ContainsKey(number) ? counts[number] : 0;
            totalSum += number * count;
        }

        var totalDiff = 0;

        for (var row = 0; row < input.Length; row++)
        {
            var numberA = columnA[row];
            var numberB = columnB[row];
            var diff = Math.Abs(numberA - numberB);
            totalDiff += diff;
        }

        return new DayOneResult()
        {
            TotalDifference = totalDiff,
            TotalSum = totalSum
        };
    }
}