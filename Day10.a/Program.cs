int clock = 1;
int register = 1;
const int offset = 20;
const int interval = 40;
int sum = 0;
foreach (ReadOnlySpan<char> line in GetInput())
{
    if (line.Length == 4)
    {
        Tick(1);
    }
    else
    {
        Tick(2);
        int value = int.Parse(line[5..]);
        register += value;
    }
}

WriteLine(sum);

void Tick(int cycles)
{
    for (int i = 0; i < cycles; i++)
    {
        if ((clock + interval - offset) % interval == 0 && clock <= 220)
        {
            sum += clock * register;
        }
        clock++;
    }
}
