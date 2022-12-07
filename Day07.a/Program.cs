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

WriteLine(Sum(root));


static long Sum(Node node)
{
    const long max = 100_000;
    long sum = 0;

    var size = node.TotalSize();
    if (size < max)
        sum += size;

    foreach (var child in node.Children)
    {
        sum += Sum(child);
    }

    return sum;
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
