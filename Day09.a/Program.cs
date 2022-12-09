using System.Numerics;

var start = Vector2.Zero;
var head = start;
var tail = head;
var visited = new HashSet<Vector2> { start };

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
