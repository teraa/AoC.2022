int sum = GetInput()
    .ChunkBy("")
    .Select(x => x.Sum(int.Parse))
    .OrderDescending()
    .Take(3)
    .Sum();

WriteLine(sum);
