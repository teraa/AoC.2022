using var enumerator = GetInput().GetEnumerator();
long result = 0;
GetSize();

WriteLine(result);


long GetSize()
{
    long size = 0;

    while (enumerator.MoveNext())
    {
        var line = enumerator.Current.AsSpan();

        if (line.StartsWith("$ cd "))
        {
            var path = line[5..];
            if (path is "..")
                break;
            if (path is not "/")
                size += GetSize();
        }
        else if (line[0] is >= '0' and <= '9')
        {
            size += long.Parse(line[..(line.IndexOf(' '))]);
        }
    }

    if (size <= 100_000)
        result += size;

    return size;
}
