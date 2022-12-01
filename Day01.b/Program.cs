var sums = new List<int>();
int current = 0;

foreach (var line in GetInput())
{
    if (line.Length == 0)
    {
        sums.Add(current);
        current = 0;
    }
    else
    {
        current += int.Parse(line);
    }
}
sums.Add(current);

WriteLine(sums.OrderByDescending(x => x).Take(3).Sum());
