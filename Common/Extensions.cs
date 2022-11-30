using System.Diagnostics;
// ReSharper disable MemberCanBePrivate.Global

namespace Common;

public static class Extensions
{
    private const string s_defaultFile = "input.txt";

    [Conditional("DEBUG")]
    public static void SetDebugInput(string filePath = s_defaultFile)
    {
        if (Console.IsInputRedirected)
            return;

        var file = File.OpenText(filePath);
        Console.SetIn(file);
    }

    public static IEnumerable<string> GetInput(string debugFilePath = s_defaultFile)
    {
        SetDebugInput(debugFilePath);
        while (Console.ReadLine() is { } line)
            yield return line;
    }
}
