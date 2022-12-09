using System.Numerics;

var head = Vector2.Zero;
var tail = head;
var visited = new HashSet<Vector2>();

foreach (ReadOnlySpan<char> line in GetInput())
{
    var sign = line[0] switch
    {
        'U' => new Vector2(0, 1),
        'D' => new Vector2(0, -1),
        'R' => new Vector2(1, 0),
        _ => new Vector2(-1, 0),
    };
    int offset = int.Parse(line[1..]);

    for (int i = 0; i < offset; i++)
    {
        head += sign;
        var move = head - tail;
        if (move.Length() >= 2)
            tail += Vector2.Clamp(move, -Vector2.One, Vector2.One);

        visited.Add(tail);
    }
}

WriteLine(visited.Count);
