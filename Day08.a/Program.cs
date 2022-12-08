var input = GetInput().ToList();
int result = 0;

for (int y = 0; y < input.Count; y++)
{
    for (int x = 0; x < input[y].Length; x++)
    {
        char c = input[y][x];
        string row = input[y];
        string col = new string(input.Select(line => line[x]).ToArray());

        if (row[..x].All(e => e < c) ||
            col[..y].All(e => e < c) ||
            row[(x + 1)..].All(e => e < c) ||
            col[(y + 1)..].All(e => e < c))
            result++;
    }
}

WriteLine(result);
