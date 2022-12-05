var chunks = GetInput()
    .ChunkBy("")
    .ToList();

var stacks = new Stack<char>[10];
for (int i = 0; i < stacks.Length; i++)
    stacks[i] = new Stack<char>();

foreach (var line in chunks[0].Take(..^1).Reverse())
{
    for (int i = 1, j = 0; i <= line.Length; i+=4, j++)
    {
        char c = line[i];
        if (c == ' ')
            continue;

        stacks[j].Push(c);
    }
}

foreach (var line in chunks[1])
{
    var parts = line.Split(' ');
    int count = int.Parse(parts[1]);
    int from = int.Parse(parts[3]) - 1;
    int to = int.Parse(parts[5]) - 1;

    var buffer = new List<char>();

    for (int i = 0; i < count; i++)
        buffer.Add(stacks[from].Pop());

    foreach (var c in buffer.AsEnumerable().Reverse())
        stacks[to].Push(c);
}

var chars = stacks
    .Select(x => x.FirstOrDefault(' '))
    .ToArray();

var result = new string(chars);

WriteLine(result);
