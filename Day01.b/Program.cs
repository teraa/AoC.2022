int sum = GetInput()
    .ChunkBy(x => x == "")
    .Select(x => x.Sum(int.Parse))
    .OrderDescending()
    .Take(3)
    .Sum();

WriteLine(sum);
