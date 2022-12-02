int sum = GetInput()
    .ChunkBy("")
    .Select(x => x.Sum(int.Parse))
    .Max();

WriteLine(sum);
