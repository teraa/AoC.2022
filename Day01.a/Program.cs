int max = 0;
int current = 0;

foreach (var line in GetInput())
{
    if (line.Length == 0)
    {
        current = 0;
    }
    else
    {
        current += int.Parse(line);
        if (current > max)
            max = current;
    }
}

WriteLine(max);
