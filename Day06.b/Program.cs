string line = GetInput().First();
const int len = 14;
var q = new Queue<char>();

for (int i = 0; i < line.Length; i++)
{
    if (q.Count == len)
        q.Dequeue();

    q.Enqueue(line[i]);

    if (q.Distinct().Count() == len)
    {
        WriteLine(i + 1);
        break;
    }
}
