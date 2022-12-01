int sum = GetInput()
    .ChunkBy(x => x == "")
    .Select(x => x.Sum(int.Parse))
    .Max();

WriteLine(sum);
