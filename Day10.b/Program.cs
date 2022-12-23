int clock = 1;
int position = 1;
const int interval = 40;
var list = new List<char>();

foreach (ReadOnlySpan<char> line in GetInput("example"))
{
    if (line.Length == 4)
    {
        Tick(1);
    }
    else
    {
        Tick(2);
        int value = int.Parse(line[5..]);
        position += value;
    }
}

void Tick(int cycles)
{
    for (int i = 0; i < cycles; i++)
    {
        var c = clock % interval;

        if (position - c is >= -2 and <= 0)
        {
            list.Add('#');
        }
        else
        {
            list.Add('.');
        }

        if (c == 0)
        {
            WriteLine(string.Join("", list));
            list.Clear();
        }

        clock++;
    }
}
