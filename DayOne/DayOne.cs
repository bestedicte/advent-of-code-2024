namespace AOC.DayOne;

public class DayOne
{
    private static string[] ParseInput()
    {
        using StreamReader reader = new("DayOne/input.txt");
        string text = reader.ReadToEnd();


        var lines = text.Split(Environment.NewLine);
        return lines;
    }

    private static (int, int) ExtractNumbers(string input)
    {
        var extractedNumbers = input.Split("   ");
        return (Int32.Parse(extractedNumbers[0]), Int32.Parse(extractedNumbers[1]));
    }

    public static string Run()
    {
        var input = ParseInput();
        int[] columnA = new int[input.Length];
        int[] columnB = new int[input.Length];

        for (int row = 0; row < input.Length; row++)
        {
            var output = ExtractNumbers(input[row]);

            columnA.SetValue(output.Item1, row);
            columnB.SetValue(output.Item2, row);
        }

        Array.Sort(columnA);
        Array.Sort(columnB);
        
        int totalDiff = 0;

        for (var row = 0; row < input.Length; row++)
        {
            var numberA = columnA[row];
            var numberB = columnB[row];
            var diff = Math.Abs(numberA - numberB);
            totalDiff += diff;
        }

        return totalDiff.ToString();
    }
}