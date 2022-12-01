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

    public static IEnumerable<IReadOnlyList<T>> ChunkBy<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        List<T>? list = null;

        using var e = source.GetEnumerator();
        bool hasNext;
        do
        {
            hasNext = e.MoveNext();
            if (!hasNext || predicate(e.Current))
            {
                yield return list ?? (IReadOnlyList<T>) Array.Empty<T>();
                list = null;
            }
            else
            {
                list ??= new();
                list.Add(e.Current);
            }
        } while (hasNext);
    }
}
