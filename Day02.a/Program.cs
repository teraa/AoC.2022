int score = 0;
foreach (var line in GetInput())
{
    int i = line[0] - 'A';
    int j = line[2] - 'X';
    score += (2 - (i - j + 4) % 3) * 3 + j + 1;
}

WriteLine(score);
