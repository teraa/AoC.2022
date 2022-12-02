int score = 0;
foreach (var line in GetInput())
{
    int i = line[0] - 'A';
    int j = line[2] - 'X';
    score += (j * 3) + (i + j + 2) % 3 + 1;
}

WriteLine(score);
