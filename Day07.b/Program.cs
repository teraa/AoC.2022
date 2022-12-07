var root = new Node
{
    Name = "/",
    Parent = null,
};
var cwd = root;

foreach (ReadOnlySpan<char> line in GetInput())
{
    if (line.StartsWith("$ cd "))
    {
        var path = line[5..];
        if (path is "..")
        {
            cwd = cwd.Parent!;
        }
        else if (path is "/")
        {
            cwd = root;
        }
        else
        {
            var name = path.ToString();
            cwd = cwd.Children.First(x => x.Name == name);
        }
    }
    else if (line[0] != '$')
    {
        if (line.StartsWith("dir "))
        {
            var node = new Node
            {
                Name = line[4..].ToString(),
                Parent = cwd,
            };
            cwd.Children.Add(node);
        }
        else
        {
            cwd.FilesSize += long.Parse(line[..(line.IndexOf(' '))]);
        }
    }
}

long required = 30_000_000 - 70_000_000 + root.TotalSize();

WriteLine(Min(root, required));


static long Min(Node dir, long required)
{
    long min = dir.TotalSize();

    foreach (var d in dir.Children)
    {
        long m = Min(d, required);
        if (min > m && m >= required)
            min = m;
    }

    return min;
}

class Node
{
    public required string Name { get; init; }
    public required Node? Parent { get; init; }
    public long FilesSize { get; set; }
    public List<Node> Children { get; } = new();

    public long TotalSize()
        => FilesSize + Children.Sum(x => x.TotalSize());
}
