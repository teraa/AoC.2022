int count = 0;
foreach (string line in GetInput())
{
    var n = line
        .Split(',', '-')
        .Select(int.Parse)
        .ToArray();

    if (n[0] <= n[3] && n[2] <= n[1])
        count++;
}

WriteLine(count);
