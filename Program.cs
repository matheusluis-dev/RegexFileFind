using System.Text.RegularExpressions;

System.Console.WriteLine(Directory.GetCurrentDirectory());

const string TAB = "  ";
var separator = new String('*', 100);

Console.WriteLine("fileName:");
var fileName = Console.ReadLine();

Console.WriteLine("regex:");
Regex regex = new Regex(Console.ReadLine());

var linesFound = new List<Line>();

using (var sr = new StreamReader(fileName))
{
    var line = string.Empty;
    int lineNumber = 0;
    while ((line = sr.ReadLine()) != null)
    {
        lineNumber++;

        if (regex.IsMatch(line)) linesFound.Add(new Line(lineNumber, line));
    }
}

Console.WriteLine(separator);

if (linesFound.Count == 0)
{
    Console.WriteLine("\nNo lines found with regex.");
}
else
{
    Console.WriteLine($"\nLines found:");

    var padSize = linesFound.LastOrDefault().lineNumber.ToString().Length + 1;

    foreach (var line in linesFound)
    {
        var print = $"{TAB}=> {line.lineNumber.ToString().PadLeft(padSize, ' ')} | {line.line}";
        Console.WriteLine(print);
    }
}

Console.WriteLine($"\n{separator}\n");

struct Line
{
    public int lineNumber;
    public string line;

    public Line(int lineNumber, string line)
    {
        this.lineNumber = lineNumber;
        this.line = line;
    }
}