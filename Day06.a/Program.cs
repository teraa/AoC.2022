string line = GetInput().First();
const int len = 4;
var q = new Queue<char>();
int i = 0;

foreach (char c in line)
{
    i++;

    if (q.Count == len)
        q.Dequeue();

    q.Enqueue(c);

    if (q.Distinct().Count() == len)
        break;
}

WriteLine(i);
