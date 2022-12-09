using System.Numerics;

var start = Vector2.Zero;
var knots = Enumerable.Repeat(start, 10).ToArray();
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
        knots[0] += sign;

        for (int j = 1; j < knots.Length; j++)
        {
            var move = knots[j - 1] - knots[j];

            if (move.Length() >= 2)
                knots[j] += Vector2.Clamp(move, -Vector2.One, Vector2.One);
        }

        visited.Add(knots[^1]);
    }
}

WriteLine(visited.Count);
