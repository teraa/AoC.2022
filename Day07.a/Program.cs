var root = new Directory
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
            var dir = cwd.Nodes
                .OfType<Directory>()
                .First(x => x.Name == name);

            cwd = dir;
        }
    }
    else if (line[0] != '$')
    {
        INode node;

        if (line.StartsWith("dir "))
        {
            node = new Directory
            {
                Name = line[4..].ToString(),
                Parent = cwd,
            };
        }
        else
        {
            int i = line.IndexOf(' ');
            node = new File
            {
                Name = line[(i + 1)..].ToString(),
                Size = long.Parse(line[..i]),
            };
        }

        cwd.Nodes.Add(node);
    }
}

WriteLine(Sum100k(root));

long Sum100k(Directory dir)
{
    const long max = 100_000;
    long sum = 0;

    var size = dir.GetSize();
    if (size < max)
        sum += size;

    foreach (var subDir in dir.Nodes.OfType<Directory>())
    {
        sum += Sum100k(subDir);
    }

    return sum;
}

interface INode
{
    string Name { get; }

    long GetSize();
}

class File : INode
{
    public required string Name { get; init; }
    public required long Size { get; init; }

    public long GetSize()
        => Size;
}

class Directory : INode
{
    private long? _size;

    public required string Name { get; init; }
    public required Directory? Parent { get; init; }
    public List<INode> Nodes { get; } = new();

    public long GetSize()
        => _size ??= Nodes.Sum(x => x.GetSize());
}
