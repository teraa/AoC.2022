int sum = 0;
foreach (ReadOnlySpan<char> line in GetInput())
{
    int i = line.Length / 2;
    int j = line[..i].IndexOfAny(line[i..]);
    char c = line[j];

    sum += c;

    if (c >= 'a')
        sum += 1 - 'a';
    else
        sum += 27 - 'A';
}

WriteLine(sum);
