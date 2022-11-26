using System.Diagnostics;

namespace Common;

public static class Extensions
{
    [Conditional("DEBUG")]
    public static void SetInput(string filePath = "input.txt")
    {
        var file = File.OpenText(filePath);
        Console.SetIn(file);
    }
}
