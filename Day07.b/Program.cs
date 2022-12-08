using var enumerator = GetInput().GetEnumerator();
var sizes = new List<long>();
long required = GetSize() - 40_000_000;
long result = sizes
    .Order()
    .First(x => x >= required);

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

    sizes.Add(size);
    return size;
}
