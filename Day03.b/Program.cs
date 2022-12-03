int sum = 0;
foreach (string[] lines in GetInput().Chunk(3))
{
    char intersect = lines[0]
        .Intersect(lines[1])
        .Intersect(lines[2])
        .Single();

    sum += intersect;

    if (intersect >= 'a')
        sum += 1 - 'a';
    else
        sum += 27 - 'A';
}

WriteLine(sum);
