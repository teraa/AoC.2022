var input = GetInput().ToList();
int result = 0;

int maxj = input.Count - 1;
for (int j = 0; j <= maxj; j++)
{
    int maxi = input[j].Length - 1;
    for (int i = 0; i <= maxi; i++)
    {
        char c = input[j][i];
        string row = input[j];
        string col = new string(input.Select(line => line[i]).ToArray());

        int im = row[..i].Reverse().TakeWhile(x => x < c).Count();
        int jm = col[..j].Reverse().TakeWhile(x => x < c).Count();
        int ip = row[(i + 1)..].TakeWhile(x => x < c).Count();
        int jp = col[(j + 1)..].TakeWhile(x => x < c).Count();

        if (i - im > 1) im++;
        if (j - jm > 1) jm++;
        if (i + ip < maxi) ip++;
        if (j + jp < maxj) jp++;

        int score = im * ip * jm * jp;

        if (score > result)
            result = score;
    }
}

WriteLine(result);
